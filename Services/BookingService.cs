using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public class BookingService:IBookingService
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;
        public BookingService(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<string> CreateBooking(BookingDTO bookingDTO)
        {
            var user = await _context.Users.FindAsync(bookingDTO.UserId);
            if (user == null)
            {
                return "User Not Found";
            }
            var trainr = await _context.Trainers.FindAsync(bookingDTO.TrainerId);
            if(trainr == null)
            {
                return "Trainer Not Found";
            }
            //Prevent Double Checking!!
            var exists = await _context.Bookings.AnyAsync(b =>
                b.TrainerId == bookingDTO.TrainerId &&
                b.Date.Date == bookingDTO.Date.Date &&
                b.TimeSlot == bookingDTO.TimeSlot);

            if (exists)
            {
                return "This Time Slot is already booked for this trainer";
            }
            var booking = new Booking
            {
                UserId = bookingDTO.UserId,
                TrainerId = bookingDTO.TrainerId,
                Date = bookingDTO.Date,
                TimeSlot = bookingDTO.TimeSlot
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            await _notificationService.AddNotification(bookingDTO.UserId, "Your Session is booked successfully");
            return "Booking Successful";
        }
    }
}
