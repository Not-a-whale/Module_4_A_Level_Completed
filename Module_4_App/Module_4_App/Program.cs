using Module_4_App;
using Module_4_App.DbModels;

class Program
{
    static void Main(string[] args)
    {
        using (ApplicationContext context = new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
        {
            context.Database.EnsureCreated();
            context.SaveChanges();

            var data = context.SingerSongs.Join(
                context.Artists,
                singerSong => singerSong.SingerId,
                artist => artist.ArtistId,
                (singerSong, artist) => new
                {
                    SongName = singerSong.Name,
                    ArtistName = artist.Name,
                    SongId = singerSong.SongId
                })
                .Join(
                context.Songs,
                singerSong => singerSong.SongId,
                song => song.SongId,
                (singerSong, song) => new
                {
                    ArtistName = singerSong.ArtistName,
                    SongName = song.Title,
                    GenreId = song.GenreId
                })
                .Join(
                context.Genres,
                song => song.GenreId,
                genre => genre.GenreId,
                (song, genre) => new
                {
                    ArtistName = song.ArtistName,
                    GenreName = genre.Title,
                    SongName = song.SongName
                });

            foreach (var song in data)
            {
                Console.WriteLine("Song Title: {0} \n\t Written by {1}, Genre: {2}", song.SongName, song.ArtistName, song.GenreName);
            }
        }
    }
}