using Comrade.Core.AirplaneCore;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.CnabFileCore;
using Comrade.Core.SystemUserCore;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;

namespace Comrade.Api.Modules;

/// <summary>
///     Persistence Extensions.
/// </summary>
public static class EntityRepositoryExtensions
{
    /// <summary>
    ///     Add Persistence dependencies varying on configuration.
    /// </summary>
    public static IServiceCollection AddEntityRepository(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAirplaneRepository, AirplaneRepository>();
        services.AddScoped<ISystemUserRepository, SystemUserRepository>();
        services.AddScoped<ICnabFileRepository, CnabFileRepository>();

        return services;
    }
}