using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Queries.TodoGroupQueries;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Handlers.TodoGroupHandlers
{
    public class GetTodoGroupQueryHandler : IRequestHandler<GetTodoGroupQuery, TodoGroupDto>
    {
        private readonly ITodoGroupRepository _groupRepository;

        public GetTodoGroupQueryHandler(ITodoGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<TodoGroupDto> Handle(GetTodoGroupQuery request, CancellationToken cancellationToken)
        {
            var item = await _groupRepository.GetByIdAsync(request.Id);
            return new TodoGroupDto
            {
                Id = item.Id,
                Name = item.Name,
                CreationDate = DateTime.Now,
                Items = item.Items.Select(x=> new TodoItemDto
                {
                    Id=x.Id,
                    Title = x.Title,    
                    Description = x.Description,
                    DueDate = x.DueDate,
                    Priority = x.Priority,
                    Status = x.Status
                }).ToList()
            };
        }
    }
}
