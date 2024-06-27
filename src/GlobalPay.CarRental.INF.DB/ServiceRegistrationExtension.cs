namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.APP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtension
{  
    public static IServiceCollection AddInfDbDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CarRentalContext>(options 
                    => options.UseSqlServer(configuration.GetConnectionString("CarRentalDbConnectionString")));
        
        services.AddScoped<ICarRentalRepository, CarRentalRepository>();
        
        return services;
    }

}
