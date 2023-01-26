namespace RecoveryApp_ASPNET.Interfaces
{
    public interface IAppRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<(bool, string)> DeleteAsync(T entity);
    }
}
