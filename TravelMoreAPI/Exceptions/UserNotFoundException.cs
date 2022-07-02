namespace TravelMoreAPI.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid id) : base($"User with following id was not found : {id.ToString()}")
        {

        }
    }
}
