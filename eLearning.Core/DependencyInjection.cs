using eLearning.Core.IService;
using eLearning.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace eLearning.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add Core services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //Todo: Add Core services here
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
