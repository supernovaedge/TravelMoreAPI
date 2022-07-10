namespace TravelMoreAPI.Exceptions
{
    public class UserWithApartmentIdNotFoundException : Exception
    {
        public UserWithApartmentIdNotFoundException(Guid id) : base($"User with following Apartment Id was not found : {id.ToString()}")
        {

        }
    }
}
