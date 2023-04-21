using Microsoft.EntityFrameworkCore;
using SimpAcc.API.Application.Interfaces;
using SimpAcc.API.Infrastructure.Data.Context;
using SimpAcc.API.Infrastructure.Data.Repositories;
using SimpAcc.API.Infrastructure.UnitOfWorks;

namespace SimpAcc.API.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DbConnection") ?? "");
            });
            services.AddScoped<DatabaseSession>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
