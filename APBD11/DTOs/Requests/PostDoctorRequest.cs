using System.ComponentModel.DataAnnotations;

namespace APBD11.DTOs.Requests
{
    public class PostDoctorRequest
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
