using MediatR;
using Medium.Application.Abstractions;
using Medium.Application.Mappers;
using Medium.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application
{
    public static class DepencyInjectionApp
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}
