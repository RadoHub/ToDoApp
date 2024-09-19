using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ToDoApp.Application.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoApp.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ErrorHandlerMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var result = string.Empty;
                switch(ex)
                {
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        _logger.LogWarning(e, "Target has not found: {TargetName}, {TargetId}", e.Name, e.Message);
                        break;
                    case BadRequestException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        _logger.LogWarning(e,"Bad Request: {ErrorMessage}", e.Message);
                        break;
                    case ToDoApp.Application.Exceptions.ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        _logger.LogWarning(e, "Validation Errors : {ValErrors}", e.Errors);
                        break;
                    case UnauthorizedException e: 
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        _logger.LogWarning(e, "Unauthorized Attempt: {ErrorMessage}", e.Message);
                        break;
                    case ForbiddenException e:
                        response.StatusCode = (int)(HttpStatusCode.Forbidden);
                        _logger.LogWarning(e, "Forbidden access: {ErrorMessage}", e.Message);
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        _logger.LogError(ex, "An unhandled exception has occurred");
                        break;
                }
                 result = JsonSerializer.Serialize(new { message = ex?.Message });

                await response.WriteAsync(result);
            }
        }
    }
}
