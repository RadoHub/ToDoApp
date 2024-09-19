using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface ITodoGroupRepository : IRepository<TodoGroup>
    {
        Task<TodoGroup> GetGroupWithItemsAsync(Guid groupId);
    }
}
