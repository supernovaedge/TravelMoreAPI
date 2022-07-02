using System.Net;
using System.Text.Json;
using TravelMoreAPI.Exceptions;
using TravelMoreAPI.Models;

namespace TravelMoreAPI.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = new ErrorDetails
                {
                    Message = error.Message,
                    StatusCode = response.StatusCode
                }.ToString();

                await response.WriteAsync(result);
            }
        }
    }
}