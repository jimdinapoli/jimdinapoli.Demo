using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SendGrid.Helpers.Errors.Model;
using SkullJocks.BenAdmin.Application.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Api
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var error = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    error = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if (error == string.Empty)
            {
                error = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(error);
        }
    }
}
