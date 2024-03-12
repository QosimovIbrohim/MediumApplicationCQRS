using Medium.Application.Abstractions;
using Medium.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Infrastructure
{
    public static class DependencyInjectionInf
    {
        public static IServiceCollection AddInfrastruct(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MediumDbContext>(ops =>
            {
                ops.UseNpgsql(configuration.GetConnectionString("DefCon"));

            });

            services.AddScoped<IApplicationDbContext, MediumDbContext>();
            return services;

        }
    }
}
