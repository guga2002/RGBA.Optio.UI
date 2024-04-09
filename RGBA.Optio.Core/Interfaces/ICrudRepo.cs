namespace Optio.Core.Interfaces
{
    public interface ICrudRepo<T> where T : class
    {
        Task<bool>AddAsync(T entity);   
        Task<bool> RemoveAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> SoftDeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}
