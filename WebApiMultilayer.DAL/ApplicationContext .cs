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
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<ProfileInfo> ProfileInfos { get; set; }

        DbSet<Mark> Marks { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Auto> Autos { get; set; }
        DbSet<Attachment> Attachments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileInfoConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new AutoConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        }

    }
}
