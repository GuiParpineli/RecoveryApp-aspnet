using RecoveryApp_ASPNET.Models;

namespace RecoveryApp_ASPNET.Services
{
    public interface IAppService
    {
        Task<List<Customer>> GetCustomerAsync();
        Task<Customer> GetCustomerAsync(Guid Id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<(bool, string)> DeleteCustomerAsync(Customer customer);

    }
}
