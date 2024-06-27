using GlobalPay.CarRental.DOM.Entities;

namespace GlobalPay.CarRental.DOM;

public class CarHireResponse
{
    public Guid Id { get; private set; }
    public Guid FeeId { get; private set; }
    public Guid CarId { get; private set; }

    public DateTime RentalDate { get; private set; } = DateTime.UtcNow;
    public DateTime ScheduledReturnDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public double Price { get; private set; }
    public double Surcharge { get; private set; }
    public double TotalPrice { get; private set; }

    public static CarHireResponse CopyFrom(CarHire carHire)
    {
        return new CarHireResponse
        {
            Id = carHire.Id,
            FeeId = carHire.FeeId,
            CarId = carHire.CarId,
            Price = carHire.Price,
            RentalDate = carHire.RentalDate,
            ReturnDate = carHire.ReturnDate,
            ScheduledReturnDate = carHire.ScheduledReturnDate,
            Surcharge = carHire.Surcharge,
            TotalPrice = carHire.TotalPrice
        };
    }
}
