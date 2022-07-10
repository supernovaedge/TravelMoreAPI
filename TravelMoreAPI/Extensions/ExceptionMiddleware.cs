using System.Net;
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
                    case UserNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case BookingNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    
                    case ApartmentNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    
                    case UserWithApartmentIdNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case BookingException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    
                    case ForbiddenException:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;

                    case UsernameInUseException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case EmailInUseException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case WrongCredentialsException:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

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

                await response.WriteAsync(result.ToString());
            }
        }
    }
}