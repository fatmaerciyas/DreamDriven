using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;

namespace DreamDriven.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpcContext, RequestDelegate next)
        {
            try
            {
                await next(httpcContext);
            }
            catch ( Exception ex )
            {
                await HandleExceptionAsync(httpcContext, ex);
                throw;
            }


        }

        private static Task HandleExceptionAsync(HttpContext httpcContext, Exception exception)
        {

            int statusCode = GetStatusCode(exception);
            httpcContext.Response.ContentType = "application/json";
            httpcContext.Response.StatusCode = statusCode;

            List<string> errors = new()
            {
                exception.Message,
                exception.InnerException.ToString()
            };

            return httpcContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());

        }

        private static int GetStatusCode(Exception exception) =>
              exception switch
              {
                  BadRequestException => StatusCodes.Status400BadRequest,
                  NotFoundException => StatusCodes.Status404NotFound,
                  ValidationException => StatusCodes.Status422UnprocessableEntity,
                  _ => StatusCodes.Status500InternalServerError, //default
              };



    }
}
