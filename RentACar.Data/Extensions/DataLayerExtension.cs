using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Data.Context;
using RentACar.Data.Repository.Abstracts;
using RentACar.Data.Repository.Concretes;
using RentACar.Data.UnitOfWorks;

namespace RentACar.Data.Extensions
{
    public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services , IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));            
            services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
