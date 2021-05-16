using CoffeeMachine.BL.Implementations;
using CoffeeMachine.BL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeMachine.BL
{
    public static class BLServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBLServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Register Types for dependency injection
            services.AddScoped<IDrinksGetterService, DrinksGetterService>();
            services.AddScoped<ICommandsCreatorService, CommandsCreatorService>();
            services.AddScoped<ICommandsGetterService, CommandsGetterService>();
            services.AddScoped<IMachineUserCreatorService, MachineUserCreatorService>();
            services.AddScoped<IMachineUserGetterService, MachineUserGetterService>();

            #endregion

            return services;
        }
    }
}
