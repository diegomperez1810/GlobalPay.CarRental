namespace GlobalPay.CarRental.APP;

public interface ICarRentalRepository
{
    IQueryable<TEntity> Get<TEntity>() where TEntity: class;
    IQueryable<TEntity> GetNotTracking<TEntity>() where TEntity: class;
    
    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity: class;
    
    Task SaveChangeAsync();
}
