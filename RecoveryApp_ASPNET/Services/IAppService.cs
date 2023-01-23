using RecoveryApp_ASPNET.Models;

namespace RecoveryApp_ASPNET.Services
{
    public interface IAppService<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T t);
        Task<T> UpdateAsync(T t);
        Task<(bool, string)> DeleteAsync(T t);

    }
}
