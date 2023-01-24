using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Data;
using RecoveryApp_ASPNET.Models;

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
            catch(Exception ex) { return null; }
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
                if(dbCustomer == null)
                {
                    return (false, "None customers found.");
                }

                _context.Customers.Remove(dbCustomer);
                await _context.SaveChangesAsync();
                return (true, "Customer got deleted.");
            }
            catch(Exception e)
            {
                return (false, $"Error. Error message:{e.Message}");
            }
        }


    }
}
        #endregion Customers
