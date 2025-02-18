using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.Repositories;
using StampingRobot.Service.Mapper;
using StampingRobot.Service.Services.Interface;
using StampingRobot.Service.Services;

namespace StampingRobot.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IRobotRepository, RobotRepository>();
            services.AddScoped<IRobotService, RobotService>();

            services.AddScoped<IStampRepository, StampRepository>();
            services.AddScoped<IStampService, StampService>();

            services.AddScoped<IStampingProcessRepository, StampingProcessRepository>();
            services.AddScoped<IStampingProcessService, StampingProcessService>();

            services.AddScoped<IStampingSessionRepository, StampingSessionRepository>();
            services.AddScoped<IStampingSessionService, StampingSessionService>();

            services.AddScoped<IStampingTaskRepository, StampingTaskRepository>();
            services.AddScoped<IStampingTaskService, StampingTaskService>();

            services.AddScoped<ITaskAssignmentRepository, TaskAssignmentRepository>();
            services.AddScoped<ITaskAssignmentService, TaskAssignmentService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);

            services.AddMemoryCache();

            services.AddHttpClient();

            return services;
        }
    }
}
