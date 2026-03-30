using SmartGymAPI.DTOs;

namespace SmartGymAPI.Services
{
    public interface IBookingService
    {
        Task<string>CreateBooking(BookingDTO bookingDTO);
    }
}
