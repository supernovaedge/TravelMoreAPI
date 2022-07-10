namespace TravelMoreAPI.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base($"Access Denied")
        {

        }
    }
}