using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ISLAGO.Datos.DBContext;
using Microsoft.EntityFrameworkCore;
using ISLAGO.Datos.Implementacion;
using ISLAGO.Datos.Interfaces;
using ISLAGO.Negocio.Implementacion;
using ISLAGO.Negocio.Interfaces;
using System.Net.Security;


namespace ISLAGO.IOC
{
    public static class Dependencia
    {

        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseNpgsql(configuration.GetConnectionString("CadenaPGSQL"));

            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddScoped<ICorreoService, CorreoService>();

            services.AddScoped<IUtilidadesService, UtilidadesService>();
            services.AddScoped<IRolService, RolService>();

        }

    }
}
