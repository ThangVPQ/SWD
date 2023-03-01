using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoice_xlsm_exporter_v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using invoice_xlsm_exporter_v3.Data.Abstract;
using invoice_xlsm_exporter_v3.Service;

namespace invoice_xlsm_exporter_v3.Infrastructure.Configuration
{
    public static class ConfigurationService
    {
        public static void RegisterContextDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<InvoiceXlsmExportexContext>(options => options
                            .UseSqlServer(configuration.GetConnectionString("invoice-xlsm-exporterConnection"),
                            options => options.MigrationsAssembly(typeof(InvoiceXlsmExportexContext).Assembly.FullName)));
        }

        public static void RegisterDI(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IDapperHelper, DapperHelper>();
            service.AddScoped<IInvoiceService, InvoiceService>();
            service.AddScoped<IUserService, UserService>();
        }
    }
}
