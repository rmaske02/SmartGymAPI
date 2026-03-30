using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _service;
        public TrainerController(ITrainerService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddTrainer(CreateTrainerDTO trainerDTO)
        {
            var result = await _service.AddTrainer(trainerDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var trainers = await _service.GetAll();
            return Ok(trainers);
        }
    }
}
