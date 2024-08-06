
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DreamDriven.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch ( Exception ex )
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            // Hata durumuna göre uygun HTTP durum kodunu al
            int statusCode = GetStatusCode(exception);

            // Hata yanıtının içeriğini oluştur
            var response = new
            {
                StatusCode = statusCode,
                Message = exception.Message,
                Details = exception.InnerException?.Message // İç hata varsa detayları da ekle
            };

            // Yanıtı JSON formatında döndür
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            // JSON yanıtı oluştur ve yaz
            var jsonResponse = JsonSerializer.Serialize(response);
            return httpContext.Response.WriteAsync(jsonResponse);
        }

        private static int GetStatusCode(Exception exception) =>
              exception switch
              {
                  ValidationException => StatusCodes.Status400BadRequest,
                  // Diğer özel hata türleri için durum kodlarını ekleyin
                  _ => StatusCodes.Status500InternalServerError, // varsayılan hata kodu
              };
    }
}


//using FluentValidation;
//using Microsoft.AspNetCore.Http;
//using SendGrid.Helpers.Errors.Model;

//namespace DreamDriven.Application.Exceptions
//{
//    public class ExceptionMiddleware : IMiddleware
//    {
//        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
//        {
//            try
//            {
//                await next(httpContext);
//            }
//            catch ( Exception ex )
//            {
//                await HandleExceptionAsync(httpContext, ex);
//                throw;
//            }


//        }

//        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
//        {

//            int statusCode = GetStatusCode(exception);
//            httpContext.Response.ContentType = "application/json";
//            httpContext.Response.StatusCode = statusCode;

//            if ( exception.GetType() == typeof(ValidationException) )
//            {

//                return httpContext.Response.WriteAsync(new ExceptionModel
//                {
//                    Errors = ( (ValidationException) exception ).Errors.Select(x => x.ErrorMessage),
//                    StatusCode = StatusCodes.Status400BadRequest
//                }.ToString());

//            }

//            List<string> errors = new()
//            {
//                exception.Message,
//            };

//            return httpContext.Response.WriteAsync(new ExceptionModel
//            {
//                Errors = errors,
//                StatusCode = statusCode
//            }.ToString());

//        }

//        private static int GetStatusCode(Exception exception) =>
//              exception switch
//              {
//                  BadRequestException => StatusCodes.Status400BadRequest,
//                  NotFoundException => StatusCodes.Status404NotFound,
//                  ValidationException => StatusCodes.Status422UnprocessableEntity,
//                  _ => StatusCodes.Status500InternalServerError, //default
//              };



//    }
//}
