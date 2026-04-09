using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.Helpers;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashBoardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet]
        public async Task<IActionResult>GetDashboard()
        {
            var stats = await _dashboardService.GetStats();
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Dashboard data fetched",
                Data = stats
            });
        }
    }
}
