namespace GlobalPay.CarRental.APP;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistrationExtension
{
    public static IServiceCollection AddAppDbDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IFeeService, FeeService>();
        services.AddScoped<ICarHireService, CarHireService>();
        
        return services;
    }
}
