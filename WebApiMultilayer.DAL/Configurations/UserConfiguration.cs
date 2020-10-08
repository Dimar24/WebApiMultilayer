using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Login)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
