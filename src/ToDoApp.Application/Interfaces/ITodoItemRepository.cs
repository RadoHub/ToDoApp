using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.ValueObejts;

namespace ToDoApp.Application.Interfaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetByGroupIdAsync(Guid groupId);
        Task<IEnumerable<TodoItem>> GetCompletedTasksAsync();
        Task<IEnumerable<TodoItem>> GetTasksDueTodayAsync();
        Task<IEnumerable<TodoItem>> GetTasksByPriorityAsync(TodoPriority priority);
    }
}
