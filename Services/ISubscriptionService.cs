using SmartGymAPI.DTOs;

namespace SmartGymAPI.Services
{
    public interface ISubscriptionService
    {
        Task<string>Subscribe(SubscribeDTO subscribeDTO);
    }
}
