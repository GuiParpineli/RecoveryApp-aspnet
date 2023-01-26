using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Data;
using RecoveryApp_ASPNET.Interfaces;
using RecoveryApp_ASPNET.Models.PlanModel;

namespace RecoveryApp_ASPNET.Services
{
    public class PlanService : IPlanRepository
    {
        private readonly AppDbContext _context;

        public PlanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Plan>> GetAllAsync()
        {
            try
            {
                return await _context.Plans.ToListAsync();
            }
            catch (Exception ex) { return null; }

        }

        public async Task<Plan> GetByIdAsync(Guid id)
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

        public async Task<Plan> AddAsync(Plan plan)
        {
            try
            {
                await _context.Plans.AddAsync(plan);
                await _context.SaveChangesAsync();
                return await _context.Plans.FindAsync(plan.Id);
            }
            catch (Exception ex) { return null; }
        }

        public async Task<Plan> UpdateAsync(Plan plan)
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

        public async Task<(bool, string)> DeleteAsync(Plan plan)
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

    }
}
