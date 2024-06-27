namespace GlobalPay.CarRental.DOM;

using GlobalPay.CarRental.DOM.Entities;

public class CarResponse
{
    public Guid Id { get; set; }
    
    public string Mark { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
    public int Year { get; private set; }
    public string Color { get; private set; } = string.Empty;
    public string CarType { get; private set; } = string.Empty;
    public int Stock { get; private set; }

    public static CarResponse CopyFrom(Car car)
    {
        return new CarResponse
        {
            Id = car.Id,
            CarType = car.CarType.ToString(),
            Color = car.Color,
            Mark = car.Mark,
            Model = car.Model,
            Stock = car.Stock,
            Year = car.Year
        };
    }
}
