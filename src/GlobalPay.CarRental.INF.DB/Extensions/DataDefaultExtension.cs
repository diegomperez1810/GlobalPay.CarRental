namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.DOM.Entities;
using GlobalPay.CarRental.DOM.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DataDefaultExtension
{
    public static void Initialize(this IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<DbContextOptions<CarRentalContext>>();
        using var context = new CarRentalContext(options);

        context.Database.Migrate();

        if(!context.Cars!.Any())
        {
            context.Cars!.Add(new Car("Toyota", "Corolla", 10).WithColor("Rojo")
                                                              .WithAño(2020)
                                                              .WithCarType(CarType.SMALL));
                                                              
            context.Cars!.Add(new Car("Honda", "Civic", 10).WithColor("Azul")
                                                           .WithAño(2019)
                                                           .WithCarType(CarType.SUV));

            context.Cars!.Add(new Car("Ford", "Mustang", 10).WithColor("Negro")
                                                            .WithAño(2022)
                                                            .WithCarType(CarType.PREMIUM));
        }

        if(!context.Fees!.Any())
        {
            var feePremium = new Fee(CarType.PREMIUM, 300);
            feePremium.WithExtraDaySurcharge(0.2, feePremium);

            var smallPeriods = new List<Period>{ new(1, 7), new(0.6, int.MaxValue) };
            var feeSmall = new Fee(CarType.SMALL, 50);
            feeSmall.WithExtraDaySurcharge(0.3, feeSmall).WithPeriods(smallPeriods);

            var suvPeriods = new List<Period> { new(1, 7), new(0.8, 30), new(0.5, int.MaxValue) };
            var feeSuv = new Fee(CarType.SUV, 150).WithExtraDaySurcharge(0.6, feeSmall).WithPeriods(suvPeriods);


            context.Fees!.Add(feePremium);   
            context.Fees!.Add(feeSmall); 
            context.Fees!.Add(feeSuv);   
        }

        context.SaveChanges();
    }
}