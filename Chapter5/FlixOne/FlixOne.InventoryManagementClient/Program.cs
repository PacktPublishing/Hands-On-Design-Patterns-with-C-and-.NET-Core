using System;
using FlixOne.InventoryManagement.Command;
using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementClient
{
    class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<ICatalogService>();
            service.Run();

            Console.WriteLine("CatalogService has completed.");
            Console.ReadLine();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IUserInterface, ConsoleUserInterface>();            
            services.AddTransient<ICatalogService, CatalogService>();
            
            // command usign a function
            services.AddTransient<Func<string, InventoryCommand>>(InventoryCommand.GetInventoryCommand);
                        
            var context = new InventoryContext();
            services.AddSingleton<IInventoryReadContext, InventoryContext>(p => context);
            services.AddSingleton<IInventoryWriteContext, InventoryContext>(p => context);
            services.AddSingleton<IInventoryContext, InventoryContext>(p => context);

           
        }        
    }
}
