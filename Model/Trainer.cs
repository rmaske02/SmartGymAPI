namespace SmartGymAPI.Model
{
    public class Trainer
    {
        public int Id {  get; set; }
        public string Name { get; set; }    
        public string Specialization {  get; set; }
        public int ExperienceYears {  get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
