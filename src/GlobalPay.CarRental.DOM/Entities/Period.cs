namespace GlobalPay.CarRental.DOM.Entities;

public class Period(double rateRatio, int days)
{
    public Guid Id { get; private set; }
    public Guid FeeId { get; private set; }

    public double RateRatio { get; private set; } = rateRatio;
    public int Days { get; private set; } = days;

    public virtual Fee? Fee { get; private set; }
}
