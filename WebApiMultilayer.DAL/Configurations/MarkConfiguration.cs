using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Configurations
{
    class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.Property(m => m.Name)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
