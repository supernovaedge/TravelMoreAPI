using TravelMoreAPI.Entities;

namespace TravelMoreAPI.Repositories
{
    public interface IGuestRepository
    {
        IEnumerable<Guest> GetGuests();
        List<Guest>? GetGuestsById(Guid id);
        void AddGuest(Guest guest);
        void SaveChanges();

    }
}
