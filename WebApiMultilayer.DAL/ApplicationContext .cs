using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMultilayer.DAL.Configurations;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Mark> Marks { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProfileInfoConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new AutoConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        }

    }
}
