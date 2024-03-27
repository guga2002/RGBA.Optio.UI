namespace Optio.Core.Interfaces
{
    public interface ICrudRepo<T> where T : class
    {
        Task<bool>Add(T entity);   
        Task<bool>Remove(T entity);
        Task<bool>Update(T entity);
        Task<bool>SoftDelete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
