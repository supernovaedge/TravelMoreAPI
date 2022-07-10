namespace TravelMoreAPI.Exceptions
{
    public class ApartmentNotFoundException : Exception
    {
        public ApartmentNotFoundException(Guid id) : base($"Booking with following id was not found : {id.ToString()}")
        {

        }
    }
}
