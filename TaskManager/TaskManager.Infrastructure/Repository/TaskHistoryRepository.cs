using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository
{
    public class TaskHistoryRepository:EfRepository<TaskHistory>
    {
        public TaskHistoryRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }
        
        public override async Task<IEnumerable<TaskHistory>> ListAllAsync()
        {
            return await _dbContext.TaskHistories.Include(t => t.User).ToListAsync();
        }

        public override async Task<TaskHistory> GetByIdAsync(int id)
        {
            return await _dbContext.TaskHistories.Include(t => t.User)
                .Where(t => t.TaskId == id).FirstOrDefaultAsync();
        }
    }
}