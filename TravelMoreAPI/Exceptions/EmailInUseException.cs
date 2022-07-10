namespace TravelMoreAPI.Exceptions
{
    public class EmailInUseException : Exception
    {
        public EmailInUseException(string email) : base($"Email: {email}  is already in use")
        {

        }
    }
}
