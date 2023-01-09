using Application.Services;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesConfiguration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
    }
}