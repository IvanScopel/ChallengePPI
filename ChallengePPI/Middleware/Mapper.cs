using Infraestructura.Profiles;

namespace WebApi.Middleware
{
    public static class Mapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(OrdenProfile));

            return services;
                
        }
    }
}
