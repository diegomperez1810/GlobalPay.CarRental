namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PeriodConfiguration : IEntityTypeConfiguration<Period>
{
    public void Configure(EntityTypeBuilder<Period> builder)
    {
        builder.ToTable("Period", "Rental");
        
        builder.HasKey(p => p.Id);

        builder.Property(a => a.Id)
               .ValueGeneratedOnAdd();
               
        builder.Property(p => p.RateRatio)
               .HasColumnType("decimal(10,2)")
               .IsRequired();
               
        builder.Property(p => p.Days)
               .HasColumnType("int")
               .IsRequired();
    }
}
