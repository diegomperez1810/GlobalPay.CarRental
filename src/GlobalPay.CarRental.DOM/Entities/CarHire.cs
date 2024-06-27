namespace GlobalPay.CarRental.DOM.Entities;

public class CarHire
{
    public Guid Id { get; private set; }
    public Guid FeeId { get; private set; }
    public Guid CarId { get; private set; }

    public DateTime RentalDate { get; private set; } = DateTime.Now.Date;
    public DateTime ScheduledReturnDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public double Price { get; private set; }
    public double Surcharge { get; private set; }
    public double TotalPrice { get; private set; }

    public virtual Fee? Fee { get; private set; }
    public virtual Car? Car { get; private set; }

    public CarHire(Fee fee, Car car, DateTime scheduledReturnDate)
    {
        FeeId = fee.Id;
        CarId = car.Id;
        ScheduledReturnDate = scheduledReturnDate.Date;
        Fee = fee;
        Car = car;
    }

    public CarHire() {}
    
    public CarHire WithPrice(double price)
    {
        Price = price;
        return this;
    }

    public CarHire ReturnCar(DateTime returnDate)
    {
        var days = (returnDate.Date - ScheduledReturnDate).Days;
        ReturnDate = returnDate.Date;

        if(days > 0)
        {
            Surcharge = Fee!.CalculateSurcharge(days);
            TotalPrice = Price + Surcharge;
        }
        
        return this;
    }

    public static CarHire RentCar(Fee fee, Car car, DateTime scheduledReturnDate)
    {
        var carRental = new CarHire(fee, car, scheduledReturnDate);
        var rentalDays = (carRental.ScheduledReturnDate.Date - carRental.RentalDate.Date ).Days;
        car.WithStock(car.Stock - 1);
        
        return carRental.WithPrice(fee.CalculatePrice(rentalDays));
    }
}
