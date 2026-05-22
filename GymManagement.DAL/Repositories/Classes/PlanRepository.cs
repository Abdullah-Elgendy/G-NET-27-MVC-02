using GymManagement.DAL.Repositories.Interfaces;
using GymManagement.DbContexts;
using GymManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {

        private readonly GymDbContext _dbContext;

        public PlanRepository(GymDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
        {
           _dbContext.Plans.Add(plan); //Add is CPU bound, does NOT interact with database so we won't use AddAsync.
           return await _dbContext.SaveChangesAsync(ct); //SaveChanges interacts with the database, that's why we will use the Async Version
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default)
        {
            _dbContext.Plans.Remove(plan);
            return await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(bool isTracking = false, CancellationToken ct = default)
        {
            //if (isTracking)
            //    return await _dbContext.Plans.ToListAsync(ct);
            //else
            //    return await _dbContext.Plans.AsNoTracking().ToListAsync(ct);

            IQueryable<Plan> query = isTracking ? _dbContext.Plans : _dbContext.Plans.AsNoTracking();
            return await query.ToListAsync(ct);
        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Plans.FindAsync(id, ct);
        }

        public async Task<int> UpdateAsync(Plan plan, CancellationToken ct = default)
        {
            _dbContext.Plans.Update(plan);
            return await _dbContext.SaveChangesAsync(ct);
        }
    }
}
