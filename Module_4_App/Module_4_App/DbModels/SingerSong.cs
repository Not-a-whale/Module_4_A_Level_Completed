using System.ComponentModel.DataAnnotations;

namespace Module_4_App.DbModels
{
    public class SingerSong
    {
        [Required]
        public int SingerSongId { get; set; }

        [Required]
        public int SingerId { get; set; }
        [Required]
        public int SongId { get; set; }
        public string Name { get; set; }
    }
}
