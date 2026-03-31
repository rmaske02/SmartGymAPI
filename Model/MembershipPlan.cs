namespace SmartGymAPI.Model
{
    public class MembershipPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public int DurationDays {  get; set; }
        public ICollection<Subscription>Subscriptions { get; set; }
    }
}
