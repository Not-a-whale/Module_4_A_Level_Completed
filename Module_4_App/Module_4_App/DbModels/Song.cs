using System.ComponentModel.DataAnnotations;
namespace Module_4_App.DbModels
{
    public class Song
    {
        [Required]
        public int SongId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        [DataType("datetime2")]
        public DateTime ReleaseDate { get; set; }
    }
}
