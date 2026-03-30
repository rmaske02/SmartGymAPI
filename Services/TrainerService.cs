using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public class TrainerService : ITrainerService
    {

        private readonly ApplicationDbContext _context;
        public TrainerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddTrainer(CreateTrainerDTO createTrainerDTO)
        {
            var trainer = new Trainer()
            {
                Name = createTrainerDTO.Name,
                Specialization = createTrainerDTO.Specialization,
                ExperienceYears = createTrainerDTO.ExperienceYears
            };
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();
            return "Trainer Added Successfully";
        }

        public async Task<List<TrainerDTO>> GetAll()
        {
            return await _context.Trainers
            .Include(t => t.Bookings)
            .Select(t => new TrainerDTO
            {
                Id = t.Id,
                Name = t.Name,
                Specialization = t.Specialization,
                ExperienceYears = t.ExperienceYears,
                Bookings = t.Bookings.Select(b => new BookingDTO
                {
                    UserId = b.UserId,
                    TrainerId = b.TrainerId,
                    Date = b.Date,
                    TimeSlot = b.TimeSlot
                }).ToList()
            })
            .ToListAsync();
        }
    }
}
