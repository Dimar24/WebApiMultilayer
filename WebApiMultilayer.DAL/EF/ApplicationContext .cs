using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.EF
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
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

    }
}
