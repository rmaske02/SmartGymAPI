using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.DTOs;
using SmartGymAPI.Helpers;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeDTO subscribeDTO)
        {
            var result = await _service.Subscribe(subscribeDTO);
            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Booking created",
                Data = result
            });
        }
    }
}
