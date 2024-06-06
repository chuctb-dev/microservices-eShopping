using eShopping.SharedKernel.Errors;
using eShopping.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace eShopping.SharedKernel.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ErrorDetails
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace
            };

            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case ArgumentException _:
                    response.StatusCode = "400";
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case ConflictException _:
                    response.StatusCode = "409";
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    break;
                case NotFoundException _:
                    response.StatusCode = "404";
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case ValidationException validationException:
                    {
                        if (validationException.Errors != null)
                        {
                            var errors = validationException.Errors;
                            var errorMessages = errors.SelectMany(error => error.Value.Select(value => value.ToString()));
                            response.Message = string.Join(Environment.NewLine, errorMessages);
                        }
                        response.StatusCode = "400";
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    }
                default:
                    response.StatusCode = "500";
                    response.StackTrace = exception.StackTrace;
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
            logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }

}