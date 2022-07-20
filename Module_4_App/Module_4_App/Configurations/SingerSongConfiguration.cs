using Module_4_App.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module_4_App.Configurations
{
    public class SingerSongConfiguration : IEntityTypeConfiguration<SingerSong>
    {
        public void Configure(EntityTypeBuilder<SingerSong> builder)
        {
            builder.HasKey(ss => ss.SingerSongId);

            builder.Property(ss => ss.SingerSongId).IsRequired(true);
            builder.Property(ss => ss.SingerId).IsRequired(true);
            builder.Property(ss => ss.SongId).IsRequired(true);
            builder.Property(ss => ss.Name);
        }
    }
}
