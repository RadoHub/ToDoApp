using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ToDoApp.Application.Commands.CreateTodoItem;
using ToDoApp.Application.Commands.TodoItemCommands;
using ToDoApp.Application.Queries.GetTodoItem;
using ToDoApp.Application.Queries.TodoItemQueries;
using ToDoApp.Domain.ValueObejts;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(IMediator mediator, ILogger<TodoItemsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            if (id == Guid.Empty)
            {
                
                return BadRequest("Invalid ID format.");
            }
            var query = new GetTodoItemQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogWarning("Id was not valid or not found in context");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodoItems()
        {
            var query = new GetAllTodoItemsQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                _logger.LogWarning($"{nameof(GetAllTodoItems)} is not found.");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetTodoItemsByGroup(Guid groupId)
        {
            var query = new GetTodoItemsByGroupQuery { GroupId = groupId };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedTodoItems()
        {
            var query = new GetCompletedTodoItemsQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("due-today")]
        public async Task<IActionResult> GetTodoItemsDueToday()
        {
            var query = new GetTodoItemsDueTodayQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("priority/{priority}")]
        public async Task<IActionResult> GetTodoItemsByPriority(TodoPriority priority)
        {
            var query = new GetTodoItemsByPriorityQuery { Priority = priority };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] CreateTodoItemCommand command)
        {
            var createdItemId = await _mediator.Send(command);

            var routeValues = new { id = createdItemId };

            var responseBody = new { Id = createdItemId };

            return CreatedAtAction(nameof(GetTodoItem), routeValues, responseBody);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = result }, new { Id = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(Guid id, [FromBody] UpdateTodoItemCommand command)
        {
            if (id == command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result) {
                return NotFound();
            }
            _logger.LogInformation("Attempt was succesfully ended over given Id: {id}", id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var command = new DeleteTodoItemCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result) NotFound();

            return NoContent();
        }
    }
}
