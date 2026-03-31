using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Data;
using SmartGymAPI.DTOs;
using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly ApplicationDbContext _context;
        public SubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Subscribe(SubscribeDTO subscribeDTO)
        {
            var user = await _context.Users.FindAsync(subscribeDTO.UserId);
            if (user == null)
            {
                return "User not found";
            }
            var plan = await _context.MembershipPlans.FindAsync(subscribeDTO.PlanId);
            if (plan == null)
            {
                return "Plan not found";
            }
            //Check Active subscription
            var exsisting = await _context.Subscriptions.FirstOrDefaultAsync(s=>s.UserId == subscribeDTO.UserId && s.IsActive);

            if (exsisting != null)
            {
                return "User Already has an active Subscription";
            }
            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddDays(plan.DurationDays);
            var subscription = new Subscription
            {
                UserId = subscribeDTO.UserId,
                MembershipPlanId = subscribeDTO.PlanId,
                StartDate = startDate,
                EndDate = endDate,
                IsActive = true
            };
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return "Subscription Successful";
        }
    }
}
