using SimpAcc.API.Application.Interfaces;
using SimpAcc.API.Application.Mappings;
using SimpAcc.API.Application.Services;

namespace SimpAcc.API.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IContactServices, ContactServices>();
            return services;
        }
    }
}
