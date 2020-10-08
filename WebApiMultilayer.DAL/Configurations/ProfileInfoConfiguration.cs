﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Configurations
{
    class ProfileInfoConfiguration : IEntityTypeConfiguration<ProfileInfo>
    {
        public void Configure(EntityTypeBuilder<ProfileInfo> builder)
        {
            builder.Property(pi => pi.NumberPhone)
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Property(pi => pi.UserId)
                .IsRequired();

        }
    }
}