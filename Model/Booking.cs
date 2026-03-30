namespace SmartGymAPI.Model
{
    public class Booking
    {
        public int Id { get; set; } 
        public int UserId {  get; set; }
        public User User { get; set; }  
        public int TrainerId {  get; set; }
        public Trainer Trainer { get; set; }    
        public DateTime Date {  get; set; }
        public string TimeSlot {  get; set; } //10 AM - 11 AM

    }
}
