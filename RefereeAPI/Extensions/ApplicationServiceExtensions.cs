using RefereeAPI.Data;
using RefereeAPI.Interfaces;
using RefereeAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace RefereeAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>       
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            //SCOPED WE HAVE TO ATTRIBUTE A TIME TO OUR TOKEN TO REFRESH, THERE ARE TWO OTHER POSSIBILITIES, BUT OR IT WILL NEVER REFRESH ULTIN THE APP IS CLOSED OR WILL REFRESH AFTER EVERY REQUEST
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}