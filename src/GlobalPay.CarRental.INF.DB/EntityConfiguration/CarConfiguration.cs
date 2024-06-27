namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Car", "Rental");
        
        builder.HasKey(p => p.Id);

        builder.Property(a => a.Id)
               .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Mark)
               .HasColumnType("varchar(100)")
               .IsRequired();

        builder.Property(p => p.Model)
               .HasColumnType("varchar(100)")
               .IsRequired();

        builder.Property(p => p.Color)
               .HasColumnType("varchar(100)")
               .IsRequired();

        builder.Property(p => p.CarType)
               .HasConversion<string>()
               .IsRequired();
               
        builder.Property(p => p.Year)
               .HasColumnType("int")
               .IsRequired();
               
        builder.Property(p => p.Stock)
               .HasColumnType("int")
               .IsRequired();
               
        builder.HasMany(o => o.CarHires)
               .WithOne(c => c.Car)
               .HasForeignKey(c => c.CarId);
    }
}
