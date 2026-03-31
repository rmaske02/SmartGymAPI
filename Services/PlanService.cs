using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public class PlanService : IPlanService
    {
        private readonly ApplicationDbContext _context;
        public PlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePlan(CreatePlanDTO createPlanDTO)
        {
            var plan = new MembershipPlan
            {
                Name = createPlanDTO.Name,
                Price = createPlanDTO.Price,
                DurationDays = createPlanDTO.DurationDays
            };
            _context.MembershipPlans.Add(plan);
            await _context.SaveChangesAsync();
            return "Plan created Successfully";
        }

        public async Task<List<MembershipPlan>> GetAllPlans()
        {
            return await _context.MembershipPlans.ToListAsync();
        }
    }
}
