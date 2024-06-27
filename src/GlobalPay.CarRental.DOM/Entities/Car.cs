namespace GlobalPay.CarRental.DOM.Entities;

using GlobalPay.CarRental.DOM.Enums;

public class Car(string mark, string model, int stock)
{
    public Guid Id { get; private set; }
    
    public string Mark { get; private set; } = mark;
    public string Model { get; private set; } = model;
    public int Year { get; private set; } = DateTime.Now.Year;
    public string Color { get; private set; } = "Rojo";
    public CarType CarType { get; private set; } = CarType.SMALL;
    public int Stock { get; private set; } = stock;
    
    public ICollection<CarHire> CarHires { get; private set; } = [];

    public Car WithColor(string color)
    {
        Color = color;
        return this;
    }

    public Car WithAño(int year)
    {
        Year = year;
        return this;
    }

    public Car WithStock(int stock)
    {
        Stock = stock;
        return this;
    }

    public Car WithCarType(CarType type)
    {
        CarType = type;
        return this;
    }

    public bool ThereIsStock()
    {
        return Stock > 0;
    }
}