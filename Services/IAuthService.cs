using SmartGymAPI.DTOs;

namespace SmartGymAPI.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDTO registerDTO);
        Task<string> Login(LoginDTO loginDTO);
    }
}
