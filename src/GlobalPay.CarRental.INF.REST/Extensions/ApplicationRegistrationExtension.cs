namespace GlobalPay.CarRental.INF.REST;

using GlobalPay.CarRental.INF.DB;

public static class ApplicationRegistrationExtension
{
    public static WebApplication UseDefaultData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        services.Initialize(); 
        return app;
    }

}
