using RecoveryApp_ASPNET.Models;
using RecoveryApp_ASPNET.Models.PlanModel;

namespace RecoveryApp_ASPNET.Services
{
    public interface IAppService
    {
        Task<List<Customer>> GetCustomersListAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<(bool, string)> DeleteCustomerAsync(Customer customer);

        //Plan Service
        Task<List<Plan>> GetPlansAsync();
        Task<Plan> GetPlanByIdAsync(Guid id);
        Task<Plan> AddPlanAsync(Plan plan);
        Task<Plan> UpdatePlanAsync(Plan plan);
        Task<(bool, string)> DeletePlanAsync(Plan plan);
    }
}
