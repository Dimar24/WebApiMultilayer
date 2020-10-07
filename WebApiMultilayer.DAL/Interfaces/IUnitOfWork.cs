using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<ProfileInfo> ProfileInfos { get; }

        IRepository<Mark> Marks { get; }
        IRepository<Model> Models { get; }
        IRepository<Auto> Autos { get; }
        IRepository<Attachment> Attachments { get; }

        void Save();
    }
}
