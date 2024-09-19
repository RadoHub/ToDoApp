using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Queries.TodoGroupQueries;

namespace ToDoApp.Application.Handlers.TodoGroupHandlers
{
    public class GetAllTodoGroupQueryHandler : IRequestHandler<GetAllTodoGroupQuery, IEnumerable<TodoGroupDto>>
    {
        private readonly ITodoGroupRepository _gorupRepository;

        public GetAllTodoGroupQueryHandler(ITodoGroupRepository gorupRepository)
        {
            _gorupRepository = gorupRepository;
        }

        public async Task<IEnumerable<TodoGroupDto>> Handle(GetAllTodoGroupQuery request, CancellationToken cancellationToken)
        {
            var items = await _gorupRepository.GetAllAsync();
            return items.Select(x => new TodoGroupDto
            {
                CreationDate = DateTime.Now,
                Id = x.Id,
                Name = x.Name,
                Items = x.Items.Select(item => new TodoItemDto
                {
                    Description = item.Description,
                    Priority = item.Priority,
                    DueDate = DateTime.Now,
                    Id = item.Id,
                    Status = item.Status,
                    Title = item.Title
                }).ToList()
            });
                
        }
    }
}
