using StamingRobot.Repository.Repositories.Interface;
using StamingRobot.Repository.Repositories;
using StampingRobot.Service.Mapper;
using StampingRobot.Service.Services.Interface;
using StampingRobot.Service.Services;
using StamingRobot.Repository.UnitOfWork.Interface;
using StamingRobot.Repository.UnitOfWork;
using StampingRobot.Service.Ultils;

namespace StampingRobot.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IRobotService, RobotService>();

            services.AddScoped<IStampService, StampService>();

            services.AddScoped<IStampingJobService, StampingJobService>();

            services.AddScoped<IStampingSessionService, StampingSessionService>();

            services.AddScoped<IStampingJobParametersService, StampingJobParametersService>();

            services.AddScoped<ITaskAssignmentService, TaskAssignmentService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ICurentUserService, CurentUserService>();

            services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);

            services.AddMemoryCache();

            services.AddHttpClient();

            return services;
        }
    }
}
