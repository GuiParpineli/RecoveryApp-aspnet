using RecoveryApp_ASPNET.Models;

namespace RecoveryApp_ASPNET.Services
{
    public interface IAppService
    {
        Task<List<Customer>> GetCustomersListAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<(bool, string)> DeleteCustomerAsync(Customer customer);
    }
}
