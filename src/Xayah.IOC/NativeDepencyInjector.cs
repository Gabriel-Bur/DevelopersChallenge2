using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xayah.Application.AutoMapper;
using Xayah.Application.Interfaces;
using Xayah.Application.Services;
using Xayah.Data;
using Xayah.Data.Interfaces;
using Xayah.Data.Repositories;


namespace Xayah.IOC
{
    public class NativeDepencyInjector
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Infra - Data
            services.AddDbContext<SqlServerContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Data - Repository
            services.AddScoped<ITransactionRepository, TransactionRepository>();


            //Application - Services
            services.AddScoped<IOFXFileReaderAppService, OFXFileReaderAppService>();
            services.AddScoped<ITransactionAppService, TransactionAppService>();
            services.AddScoped<IConciliationAppService, ConciliationAppService>();


            //Application - AutoMapper
            services.AddAutoMapper(typeof(DomainToViewModel), typeof(ViewModelToDomain));

        }
    }
}
