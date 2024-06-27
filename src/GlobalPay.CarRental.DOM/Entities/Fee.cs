namespace GlobalPay.CarRental.DOM.Entities;

using GlobalPay.CarRental.DOM.Enums;

public class Fee
{
    public Guid Id { get; private set; }
    public Guid? FeeSurchargeId { get; private set; }

    public double BasePrice { get; private set; }
    public CarType CarType { get; private set; }
    public double ExtraDaySurcharge { get; private set; } = 0;
    
    public ICollection<Period> Periods { get; private set; } = [];
    public ICollection<CarHire> CarHires { get; private set; } = [];
    public virtual Fee? FeeSurcharge { get; private set; }

    public Fee(CarType carType, double price)
    {
        BasePrice = price;
        CarType = carType;
    }

    public Fee() {}

    public Fee WithExtraDaySurcharge(double surcharge, Fee feeSurcharge)
    {
        ExtraDaySurcharge = surcharge;
        FeeSurcharge = feeSurcharge;

        return this;
    }

    public Fee WithPeriods(ICollection<Period> periods)
    {
        Periods = periods;
        return this;
    }

    public double CalculateSurcharge(int days)
    {
        return days * (BasePrice + FeeSurcharge!.BasePrice*ExtraDaySurcharge);
    }

    public double CalculatePrice(int days)
    {
        var periods = Periods.Where(per => per.Days <= days)
                             .OrderBy(per => per.Days);

        if(!periods.Any()) return days*BasePrice;

        var daysToProcess = 0;
        var price = 0.0;

        foreach(var period in periods)
        {
            price += (period.Days - daysToProcess) * BasePrice*period.RateRatio;
            daysToProcess = period.Days;
        }

        if(periods.Count() < Periods.Count)
        {
            var period = Periods.OrderBy(per => per.Days)
                                .ElementAt(periods.Count());
            price += (days - daysToProcess)*BasePrice*period.RateRatio; 
        }

        return price;
    }
}
