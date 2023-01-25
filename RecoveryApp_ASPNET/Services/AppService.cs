using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Data;
using RecoveryApp_ASPNET.Models;
using RecoveryApp_ASPNET.Models.PlanModel;

namespace RecoveryApp_ASPNET.Services
{
    public class AppService : IAppService
    {

        private readonly AppDbContext _context;

        public AppService(AppDbContext context)
        {
            _context = context;
        }

        #region Customers
        public async Task<List<Customer>> GetCustomersListAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            try
            {
                return await _context.Customers.Include(a => a.Address)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return await _context.Customers.FindAsync(customer.Id);
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCustomerAsync(Customer customer)
        {
            try
            {
                var dbCustomer = await _context.Customers.FindAsync(customer.Id);
                if (dbCustomer == null)
                {
                    return (false, "None customers found.");
                }

                _context.Customers.Remove(dbCustomer);
                await _context.SaveChangesAsync();
                return (true, "Customer got deleted.");
            }
            catch (Exception e)
            {
                return (false, $"Error. Error message:{e.Message}");
            }
        }

        #endregion Customers


        #region Plan

        public async Task<List<Plan>> GetPlansAsync()
        {
            try
            {
                return await _context.Plans.ToListAsync();
            }
            catch (Exception ex) { return null; }

        }

        public async Task<Plan> GetPlanByIdAsync(Guid id)
        {
            try
            {
                return await _context.Plans.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Plan> AddPlanAsync(Plan plan)
        {
            try
            {
                await _context.Plans.AddAsync(plan);
                await _context.SaveChangesAsync();
                return await _context.Plans.FindAsync(plan.Id);
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Plan> UpdatePlanAsync(Plan plan)
        {
            try
            {
                _context.Entry(plan).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return plan;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeletePlanAsync(Plan plan)
        {
            try
            {
                var dbPlan = await _context.Plans.FindAsync(plan.Id);
                if (dbPlan == null)
                {
                    return (false, "Plan could not be found");
                }

                _context.Plans.Remove(plan);
                await _context.SaveChangesAsync();
                return (true, "Plan deleted suceffully.");
            }
            catch (Exception e)
            {
                return (false, $"error for deleting, {e.Message}");
            }
        }

        #endregion Plan
    }
}
