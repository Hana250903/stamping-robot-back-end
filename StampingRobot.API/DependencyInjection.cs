using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.Repositories;
using StampingRobot.Service.Mapper;

namespace StampingRobot.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);

            services.AddMemoryCache();

            services.AddHttpClient();

            return services;
        }
    }
}
