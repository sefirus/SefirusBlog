using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Repositories;

public static class ApplicationRepositoriesConfiguration
{
    public static void AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));
    }
}