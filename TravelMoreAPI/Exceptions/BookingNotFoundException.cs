namespace TravelMoreAPI.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException(Guid id) : base($"Booking with following id was not found : {id.ToString()}")
        {

        }
    }
}
