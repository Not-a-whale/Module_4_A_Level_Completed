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

            Artist TheYoungest = context.Artists.OrderBy(artist => artist.DateOfBirth).Last();
            Console.WriteLine($"The youngest singer is {TheYoungest.Name}, his date of birth is: {TheYoungest.DateOfBirth.ToString()}");
            IQueryable<Song> songs = context.Songs.Where(s => s.ReleaseDate <= TheYoungest.DateOfBirth);
            int count = songs.Count();
            Console.WriteLine($"There are {count} songs written before {TheYoungest.DateOfBirth.ToString()}");
            Console.WriteLine("They are: ");
            foreach(Song song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}