using System.ComponentModel.DataAnnotations;

namespace Module_4_App.DbModels
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
