using OrderService.Application.Core.IRepositories;
using OrderService.Application.Core.Repositories;
using OrderService.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using CustomLibrary.Services;
using OrderService.Infrastructure.Services;

namespace OrderService
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(builderOptions =>
            {
                builderOptions.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(60), errorNumbersToAdd: null);
                });
            });
            return services;
        }
        public static IServiceCollection AddRequiredService(this IServiceCollection services)
        {
            services.AddHttpClient();

			services.AddTransient<IIdentityService, IdentityService>();
			services.AddTransient<IPrivateUserIdService, PrivateUserIdService>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();

            return services;
        }
       
    }
}
