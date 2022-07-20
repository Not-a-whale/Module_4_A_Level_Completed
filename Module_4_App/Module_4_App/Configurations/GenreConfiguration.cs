
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_App.DbModels;

namespace Module_4_App.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.GenreId);

            builder.Property(e => e.GenreId).IsRequired(true);
            builder.Property(e => e.Title).IsRequired(true);
        }
    }
}
