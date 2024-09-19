using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commands.ToDoGroupCommands;
using ToDoApp.Application.Queries.TodoGroupQueries;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTodoGroups()
        {
            var query = new GetAllTodoGroupQuery();
            var results = await _mediator.Send(query);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoGroup(Guid id)
        {
            var query = new GetTodoGroupQuery{Id = id};
            var result = await _mediator.Send(query);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoGroup([FromBody] CreateTodoGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateTodoGroup), result);
        }
    }
}
