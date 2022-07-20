using Microsoft.EntityFrameworkCore;
using Module_4_App.Configurations;
using Module_4_App.DbModels;

namespace Module_4_App
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SingerSong> SingerSongs { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SingerSongConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Title = "Rock" },
                new Genre() { GenreId = 2, Title = "Folk" },
                new Song() { GenreId = 3, Title = "Pop" },
                new Song() { GenreId = 4, Title = "Blues" }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song() { SongId = 1, Title = "Yesterday", Duration = new TimeSpan(0, 2, 3), ReleaseDate = new DateTime(1965, 7, 2), GenreId = 1 },
                new Song() { SongId = 2, Title = "My Way", Duration = new TimeSpan(0, 4, 35), ReleaseDate = new DateTime(1969, 11, 30), GenreId = 4 },
                new Song() { SongId = 3, Title = "Hallelujah", Duration = new TimeSpan(0, 4, 38), ReleaseDate = new DateTime(1984, 5, 1), GenreId = 3 },
                new Song() { SongId = 4, Title = "Sag mir wo die Blumen sind", Duration = new TimeSpan(0, 7, 23), ReleaseDate = new DateTime(1962, 1, 1), GenreId = 2 },
                new Song() { SongId = 5, Title = "Don't dream it's over", Duration = new TimeSpan(0, 3, 58), ReleaseDate = new DateTime(1986, 4, 4), GenreId = 2 }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist() { ArtistId = 1, Name = "Paul McCartney", DateOfBirth = new DateTime(1942, 6, 1), InstagramUrl = "www.instagram.com/paulmccartney" },
                new Artist() { ArtistId = 2, Name = "Marlene Dietrich", DateOfBirth = new DateTime(1901, 4, 6) },
                new Artist() { ArtistId = 3, Name = "Leonard Cohen", DateOfBirth = new DateTime(1934, 8, 1) },
                new Artist() { ArtistId = 4, Name = "Francis Albert Sinatra", DateOfBirth = new DateTime(1915, 11, 1) },
                new Artist() { ArtistId = 5, Name = "Neil Mullane Finn", DateOfBirth = new DateTime(1958, 4, 1), InstagramUrl = "www.instagram.com/neilfinnofficial" },
                new Artist() { ArtistId = 6, Name = "Leigh Anne Bingham Nash", DateOfBirth = new DateTime(1976, 5, 1), InstagramUrl = "www.instagram.com/leighbirdnash/" },
                new Artist() { ArtistId = 7, Name = "Joan Chandos Baez", DateOfBirth = new DateTime(1941, 11, 9), InstagramUrl = "www.instagram.com/joancbaezofficial" },
                new Artist() { ArtistId = 8, Name = "Elvis Aaron Presley", DateOfBirth = new DateTime(1935, 1, 8) }
            );

            modelBuilder.Entity<SingerSong>().HasData(
                new SingerSong() { SingerSongId = 1, SingerId = 1, SongId = 1, Name = "Yesterday" },
                new SingerSong() { SingerSongId = 2, SingerId = 2, SongId = 4, Name = "Sag mir wo die Blumen sind" },
                new SingerSong() { SingerSongId = 3, SingerId = 3, SongId = 3, Name = "Hallelujah" },
                new SingerSong() { SingerSongId = 4, SingerId = 4, SongId = 2, Name = "My Way" },
                new SingerSong() { SingerSongId = 5, SingerId = 5, SongId = 5, Name = "Don't dream it's over" },
                new SingerSong() { SingerSongId = 6, SingerId = 6, SongId = 5, Name = "Don't dream it's over" },
                new SingerSong() { SingerSongId = 7, SingerId = 7, SongId = 4, Name = "Sag mir wo die Blumen sind" },
                new SingerSong() { SingerSongId = 8, SingerId = 8, SongId = 1, Name = "Yesterday" }
            );
        }
    }
}
