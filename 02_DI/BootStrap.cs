using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Repositories;
using Services;

namespace _02_DI {
    public class Bootstrap {
        
       public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static void Configure (IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<WG2RContext> (options => {
                options.UseMySql (configuration.GetConnectionString ("DefaultConnection"));
                options.UseLoggerFactory (MyLoggerFactory);
                options.EnableSensitiveDataLogging ();
                options.UseLazyLoadingProxies ();
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPessoaFisicaService, PessoaFisicaService>();
        }
    }
}



