using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Data;
using RecoveryApp_ASPNET.Models;

namespace RecoveryApp_ASPNET.Services
{
    public class AppService : IAppService  
    {

        private readonly AppDbContext _db;

        public AppService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customer>> GetCustomerAsync()
        {
            try
            {
                return await _db.Customers.ToListAsync();
            }
            catch (Exception ex)
            { 
                return null;
            }
        }

        public async Task<Customer> GetCustomerAsync(Guid Id)
        {
            try
            {
                return await _db.Customers.FindAsync(Id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            try
            {
                await _db.Customers.AddAsync(customer);
                await _db.SaveChangesAsync();
                return await _db.Customers.FindAsync(customer.Id);
            }catch(Exception ex) 
            {
                return null; 
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _db.Entry(customer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return customer;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCustomerAsync(Customer customer)
        {
            try
            {
                var dbCustomer = await _db.Customers.FindAsync(customer.Id);
                if(dbCustomer == null)
                {
                    return (false, "Customer could not be found");
                }
                _db.Customers.Remove(dbCustomer);
                await _db.SaveChangesAsync();
                return (true, "Customer got deleted.");
            }
            catch(Exception ex)
            {
                return(false, $"An error occured. Error Message: {ex.Message}");
            }
        }

    }
}
