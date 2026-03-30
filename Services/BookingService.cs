using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public class BookingService:IBookingService
    {
        private readonly ApplicationDbContext _context;
        public BookingService(ApplicationDbContext context)
        {
            _context = context;
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
            return "Booking Successful";
        }
    }
}
