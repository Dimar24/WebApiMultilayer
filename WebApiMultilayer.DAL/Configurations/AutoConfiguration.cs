using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Configurations
{
    class AutoConfiguration : IEntityTypeConfiguration<Auto>
    {
        public void Configure(EntityTypeBuilder<Auto> builder)
        {
            builder.Property(a => a.Color)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(a => a.EnginyType)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(a => a.Transmition)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(a => a.MaxSpeed)
                .IsRequired();

            builder.Property(a => a.Year)
                .IsRequired();

            builder.Property(a => a.EnginyCapacity)
                .IsRequired();

            builder.Property(a => a.ModelId)
                .IsRequired();

            builder.Property(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.Location)
                .HasColumnType("varchar(255)")
                .IsRequired();
        }
    }
}
