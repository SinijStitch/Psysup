using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Psysup.Domain.Services.Auth;
using Psysup.Domain.Services.Hash;

namespace Psysup.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IAuthService, AuthService>();

        return services;
    }
}