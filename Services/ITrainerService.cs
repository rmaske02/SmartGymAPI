using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public interface ITrainerService
    {
        Task<string>AddTrainer(CreateTrainerDTO createTrainerDTO);
        Task<List<TrainerDTO>> GetAll();
    }
}
