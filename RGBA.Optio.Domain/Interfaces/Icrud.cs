namespace RGBA.Optio.Domain.Interfaces
{
    public interface Icrud<T>where T:class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> RemoveAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> SoftDeleteAsync(Guid id);
    }
}
