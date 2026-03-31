using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public interface IPlanService
    {
        Task<string>CreatePlan(CreatePlanDTO createPlanDTO);
        Task<List<MembershipPlan>> GetAllPlans();
    }
}
