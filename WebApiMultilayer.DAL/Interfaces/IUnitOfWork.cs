using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> Users { get; }
        RoleManager<IdentityRole> Roles { get; }
        SignInManager<User> SignIn { get; }

        IRepository<Mark> Marks { get; }
        IRepository<Model> Models { get; }
        IRepository<Auto> Autos { get; }
        IRepository<Attachment> Attachments { get; }

        void Save();
    }
}
