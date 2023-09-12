using Corso.Core.Entities.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corso.Infrastructure.Data.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.Title).IsRequired()
            .HasMaxLength(100);
        builder.Property(m => m.ReleaseDate)
            .HasColumnType("date");

    }
}
