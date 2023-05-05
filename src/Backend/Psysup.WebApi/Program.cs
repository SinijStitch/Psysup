using System.Globalization;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Psysup.DataAccess;
using Psysup.DataAccess.Data;
using Psysup.Domain;
using Psysup.Domain.Constants;
using Psysup.WebApi.Middlewares.Error;
using Serilog;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    // Configuration.
    builder.Host.UseSerilog();

    builder.Services.AddDataAccess(builder.Configuration);
    builder.Services.AddDomain();

    builder.Services
        .AddControllers()
        .AddNewtonsoftJson(options => { options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; });

    builder.Services.AddHttpContextAccessor();

    builder.Services
        .AddAuthentication(CookieConstants.CookieScheme)
        .AddCookie(CookieConstants.CookieScheme, options =>
        {
            options.Cookie.Name = CookieConstants.CookieName;
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Task.CompletedTask;
            };
            options.Events.OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Task.CompletedTask;
            };
        });

    builder.Services.AddCors(options => options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins("https://localhost:3000").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
    }));

    var app = builder.Build();

    await using (var scope = app.Services.CreateAsyncScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<PsysupDbContext>();
        await dbContext.Database.MigrateAsync();
    }

    // Middleware
    app.UseCors();
    app.UseHttpsRedirection();
    app.UseErrorHandler();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Application terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}