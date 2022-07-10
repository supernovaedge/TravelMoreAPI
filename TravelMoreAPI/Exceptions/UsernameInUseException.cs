namespace TravelMoreAPI.Exceptions
{
    public class UsernameInUseException : Exception
    {
            public UsernameInUseException(string username) : base($"Username: {username}  is already in use")
            {

            }   
    }
}

