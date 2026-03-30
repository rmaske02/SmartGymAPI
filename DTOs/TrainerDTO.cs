namespace SmartGymAPI.DTOs
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }

        public List<BookingDTO> Bookings { get; set; }
    }
}
