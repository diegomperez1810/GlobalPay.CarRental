namespace GlobalPay.CarRental.DOM;

using GlobalPay.CarRental.DOM.Entities;

public class FeeResponse
{
    public Guid Id { get; set; }

    public double BasePrice { get; set; }
    public string CarType { get; set; } = string.Empty;

    public double ExtraDaySurcharge { get; set; }
    public double ExtraPriceSurcharge { get; set; }


        public static FeeResponse CopyFrom(Fee fee)
    {
        return new FeeResponse
        {
            Id = fee.Id,
            BasePrice = fee.BasePrice,
            CarType = fee.CarType.ToString(),
            ExtraDaySurcharge = fee.ExtraDaySurcharge,
            ExtraPriceSurcharge = fee.FeeSurcharge != null ? fee.FeeSurcharge.BasePrice : 0
        };
    }

}
