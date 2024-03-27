namespace RGBA.Optio.Domain.Interfaces
{
    public interface Icrud<T>where T:class
    {
        Task<bool> Add(T entity);
        Task<bool> Remove(T entity);
        Task<bool> Update(T entity);
        Task<bool> SoftDelete(Guid id);
    }
}
