using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Data;
using RecoveryApp_ASPNET.Models;

namespace RecoveryApp_ASPNET.Services
{
    public class CustomerService : IAppService<Customer>
    {

        private readonly AppDbContext _db;

        public CustomerService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customer>> GetAsync()
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

        public async Task<Customer> GetByIdAsync(Guid Id)
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

        public Task<Customer> AddAsync(Customer t)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string)> DeleteAsync(Customer t)
        {
            throw new NotImplementedException();
        }


        public Task<Customer> UpdateAsync(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
