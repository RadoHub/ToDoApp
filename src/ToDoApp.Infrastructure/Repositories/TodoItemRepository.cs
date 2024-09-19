using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.ValueObejts;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repositories
{
    public class TodoItemRepository : EfBaseRepository<TodoItem>, ITodoItemRepository
    {

        public TodoItemRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<TodoItem>> GetByGroupIdAsync(Guid groupId)
        {
            return await _dbSet.Where(x=> EF.Property<Guid>(groupId, "TodoGropId") == groupId).ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetCompletedTasksAsync()
        {
            return await _dbSet.Where(x=> x.Status == TodoStatus.Completed).ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetTasksByPriorityAsync(TodoPriority priority)
        {
            return await _dbSet.Where(x=> x.Priority == priority).ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetTasksDueTodayAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _dbSet.Where(x=>x.DueDate == today).ToListAsync();
        }
    }
}
