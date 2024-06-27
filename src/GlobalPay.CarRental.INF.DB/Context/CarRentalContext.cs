namespace GlobalPay.CarRental.INF.DB;

using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;

public class CarRentalContext(DbContextOptions<CarRentalContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CarHireConfiguration());
        modelBuilder.ApplyConfiguration(new FeeConfiguration());
        modelBuilder.ApplyConfiguration(new PeriodConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Car>? Cars { get; set; }
    public DbSet<CarHire>? CarHires { get; set; }
    public DbSet<Fee>? Fees { get; set; }
    public DbSet<Period>? Periods { get; set; }
}
