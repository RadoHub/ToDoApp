using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repositories
{
    public class TodoGroupRepository : EfBaseRepository<TodoGroup>, ITodoGroupRepository
    {
        public TodoGroupRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<TodoGroup> GetGroupWithItemsAsync(Guid groupId)
        {
            return await _dbSet.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == groupId);
            //return await _appDbContext.TodoGroups.Include("_items").FirstOrDefaultAsync(g => g.Id == groupId);
        }
    }
}
