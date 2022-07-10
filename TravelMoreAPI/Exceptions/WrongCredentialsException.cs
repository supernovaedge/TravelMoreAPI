namespace TravelMoreAPI.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException() : base($"Wrong Username or Password")
            {

            }
    }
}
