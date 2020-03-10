using System.Linq;

namespace UDemyTestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }
}