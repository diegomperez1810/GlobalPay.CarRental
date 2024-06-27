namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FeeConfiguration : IEntityTypeConfiguration<Fee>
{
    public void Configure(EntityTypeBuilder<Fee> builder)
    {
        builder.ToTable("Fee", "Rental");

        builder.HasKey(p => p.Id);

        builder.Property(a => a.Id)
               .ValueGeneratedOnAdd();
               
        builder.Property(p => p.BasePrice)
               .HasColumnType("decimal(10,2)")
               .IsRequired();
               
        builder.Property(p => p.CarType)
               .HasConversion<string>()
               .IsRequired();
               
        builder.Property(p => p.ExtraDaySurcharge)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

        builder.HasMany(o => o.Periods)
               .WithOne(c => c.Fee)
               .HasForeignKey(c => c.FeeId);
               
        builder.HasMany(o => o.CarHires)
               .WithOne(c => c.Fee)
               .HasForeignKey(c => c.FeeId);
       
        builder.HasOne(f => f.FeeSurcharge)
               .WithMany()
               .HasForeignKey(f => f.FeeSurchargeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
