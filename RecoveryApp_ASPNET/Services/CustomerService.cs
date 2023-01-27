using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Data;
using RecoveryApp_ASPNET.Interfaces;
using RecoveryApp_ASPNET.Models.CustomerModel;

namespace RecoveryApp_ASPNET.Services
{
    public class CustomerService : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Customer> GetByIdAsync(Guid id)
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


        public async Task<Customer> AddAsync(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return await _context.Customers.FindAsync(customer.Id);
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Customer> UpdateAsync(Customer customer)
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

        public async Task<(bool, string)> DeleteAsync(Customer customer)
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
    }
}
