using FlixOne.DB.Contexts;
using FlixOne.DB.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.DB.DI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddDbContext<ProductContext>(
                o => o.UseSqlServer("Data Source=.;Initial Catalog=FlixOneEFCore;Integrated Security=True;MultipleActiveResultSets=True",
                    assembly => assembly.MigrationsAssembly(typeof(ProductContext).Assembly.FullName)));
            return serviceCollection;
        }
        public static ServiceProvider GetProvider()
        {
            var serviceCollection = new ServiceCollection();

            var provider = serviceCollection.AddService().BuildServiceProvider();
            return provider;
        }
        public static ServiceProvider GetProvider(this IServiceCollection serviceCollection)
        {
            var provider = serviceCollection.BuildServiceProvider();
            return provider;
        }
    }
}