using System.ComponentModel.DataAnnotations;

namespace SmartGymAPI.DTOs
{
    public class CreateTrainerDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Range(1, 50)]
        public int ExperienceYears { get; set; }
    }
}
