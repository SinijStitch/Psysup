using Psysup.DataAccess;
using Psysup.Domain;
using Psysup.WebApi.Middlewares.Error;

var builder = WebApplication.CreateBuilder(args);

// Configuration.
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddDomain();
builder.Services.AddControllers();

var app = builder.Build();

// Middleware

app.UseErrorHandler();
app.MapControllers();

app.Run();