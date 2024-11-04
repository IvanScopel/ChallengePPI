
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkRepository;
using UnitOfWorkRepository.Generic;
using UnitOfWorkRepository.Repository;
using UnitOfWorkRepository.Repository.Models;

namespace WebApi.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IUnitOfWorkRepository), typeof(UOWRepository));
            
            return services;
        }
    }
}