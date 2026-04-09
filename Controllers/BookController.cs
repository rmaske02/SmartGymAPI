using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.DTOs;
using SmartGymAPI.Helpers;
using SmartGymAPI.Model;
using SmartGymAPI.Services;
using System.Runtime.InteropServices;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookController(IBookingService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult>CreateBooking(BookingDTO bookingDTO)
        {
            var result = await _service.CreateBooking(bookingDTO);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Trainer list fetched",
                Data = result
            });
        }
    }
}
