using Module_4_App.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module_4_App.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.SongId);

            builder.Property(s => s.SongId).IsRequired(true);
            builder.Property(s => s.ReleaseDate).IsRequired(true);
            builder.Property(s => s.Title).IsRequired(true);
            builder.Property(s => s.Duration).IsRequired(true);
        }
    }
}
