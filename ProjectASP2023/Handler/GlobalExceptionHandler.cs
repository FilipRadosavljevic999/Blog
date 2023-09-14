using Application.Exceptions;
//using System.ComponentModel.DataAnnotations;

namespace ProjectASP2023.Handler
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                if (ex is ForbiddenUseCaseExecutionException)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                }

                if (ex is EntityNotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }
                if(ex is UnauthorizedAccessException)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                }
                if (ex is FluentValidation.ValidationException e)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        
                        errors = e.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }

                if (ex is UseCaseConflictException conflictEx)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new { message = conflictEx.Message };
                }


                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
