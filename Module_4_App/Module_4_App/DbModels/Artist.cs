using System.ComponentModel.DataAnnotations;

namespace Module_4_App.DbModels
{
    public class Artist
    {
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"(?:\+1\D*)?([2-9]\d{2})\D*([2-9]\d{2})\D*(\d{4})",
        ErrorMessage = "Please enter correct phone number")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string InstagramUrl { get; set; }
    }
}
