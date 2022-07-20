using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_App.DbModels;

namespace Module_4_App.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.ArtistId);

            builder.Property(a => a.ArtistId).IsRequired(true);
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(a => a.Email).HasMaxLength(50).IsRequired(false);
            builder.Property(a => a.InstagramUrl).IsRequired(false);
            builder.Property(a => a.DateOfBirth).IsRequired(true);
            builder.Property(a => a.Phone).IsRequired(false);

        }
    }
}
