namespace SmartGymAPI.DTOs
{
    public class BookingDTO
    {
        public int UserId { get; set; }
        public int TrainerId { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
    }
}
