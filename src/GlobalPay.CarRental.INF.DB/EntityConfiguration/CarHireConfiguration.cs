namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarHireConfiguration : IEntityTypeConfiguration<CarHire>
{
    public void Configure(EntityTypeBuilder<CarHire> builder)
    {
        builder.ToTable("CarHire", "Rental");
        
        builder.HasKey(p => p.Id);

        builder.Property(a => a.Id)
               .ValueGeneratedOnAdd();
               
        builder.Property(p => p.RentalDate)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(p => p.ScheduledReturnDate)
               .HasColumnType("datetime")
               .IsRequired();
               
        builder.Property(p => p.ReturnDate)
               .HasColumnType("datetime");

        builder.Property(p => p.Price)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

        builder.Property(p => p.Surcharge)
               .HasColumnType("decimal(10,2)")
               .IsRequired();
               
        builder.Property(p => p.TotalPrice)
               .HasColumnType("decimal(10,2)")
               .IsRequired();
    }
}
