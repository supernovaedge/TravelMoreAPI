namespace TravelMoreAPI.Exceptions
{
    public class BookingException : Exception
    {
        public BookingException(string details) : base($"{details}")
        {

        }
    }
}