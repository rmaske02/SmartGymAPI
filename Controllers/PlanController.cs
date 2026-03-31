using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.DTOs;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _service;
        public PlanController(IPlanService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult>CreatePlan(CreatePlanDTO createPlanDTO)
        {
            var result = await _service.CreatePlan(createPlanDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult>GetAllPlan()
        {
            var plan = await _service.GetAllPlans();
            return Ok(plan);
        }
    }
}
