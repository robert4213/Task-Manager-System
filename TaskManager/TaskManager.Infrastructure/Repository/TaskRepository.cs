using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.RepositoryInterface;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository
{
    public class TaskRepository:EfRepository<Tasks>
    {
        public TaskRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Tasks>> ListAllAsync()
        {
            return await _dbContext.Tasks.Include(t => t.User).ToListAsync();
        }

        public override async Task<Tasks> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.Include(t => t.User)
                .Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}