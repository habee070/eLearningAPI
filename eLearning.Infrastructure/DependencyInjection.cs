using eLearning.Core.IRepository;
using eLearning.Core.IService;
using eLearning.Infrastructure.DbContext;
using eLearning.Infrastructure.Repository;
using eLearning.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace eLearning.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //Todo: Add infrastructure services here
        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<DapperDbContext>();

        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }
}
