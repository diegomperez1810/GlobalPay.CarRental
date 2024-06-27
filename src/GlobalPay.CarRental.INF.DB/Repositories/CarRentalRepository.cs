namespace GlobalPay.CarRental.INF.DB;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalPay.CarRental.APP;
using Microsoft.EntityFrameworkCore;

public class CarRentalRepository(CarRentalContext context) : ICarRentalRepository
{
	private readonly CarRentalContext _context = context;

    public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        await _context.AddRangeAsync(entities);
    }

    public IQueryable<TEntity> Get<TEntity>() where TEntity : class
    {
        return _context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetNotTracking<TEntity>() where TEntity : class
    {
        return _context.Set<TEntity>().AsNoTracking();
    }
    
    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}
