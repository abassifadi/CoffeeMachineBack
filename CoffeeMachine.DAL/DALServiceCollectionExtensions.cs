using CoffeeMachine.DAL.Implementations;
using CoffeeMachine.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeMachine.DAL
{
    public static class DALServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<CoffeeMachineDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("CoffeeMachineConnection"),
                    serverOptions => serverOptions.MigrationsAssembly(typeof(CoffeeMachineDbContext).Assembly.FullName));
                o.EnableSensitiveDataLogging(true);

            }) ;

            #region Register Types for dependency injection
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork<CoffeeMachineDbContext>>();
            #endregion

            return services;
        }
    }
}
