using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Helpers;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _service;
        private readonly ILogger<TrainerController> _logger;
        public TrainerController(ITrainerService service,ILogger<TrainerController>logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddTrainer(CreateTrainerDTO trainerDTO)
        {
            var result = await _service.AddTrainer(trainerDTO);
            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Trainer added",
                Data = result
            });
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var trainers = await _service.GetAll();
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Trainer list fetched",
                Data = trainers
            });
        }
    }
}
