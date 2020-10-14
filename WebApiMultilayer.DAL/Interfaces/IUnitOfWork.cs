using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Identity;

namespace WebApiMultilayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IRepository<ClientProfile> ClientProfiles { get; }

        IRepository<Mark> Marks { get; }
        IRepository<Model> Models { get; }
        IRepository<Auto> Autos { get; }
        IRepository<Attachment> Attachments { get; }

        void Save();
    }
}
