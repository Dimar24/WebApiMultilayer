using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Identity;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        private ClientProfileRepository clientProfileRepository;

        private MarkRepository markRepository;
        private ModelRepository modelRepository;
        private AutoRepository autoRepository;
        private AttachmentRepository attachmentRepository;

        public EFUnitOfWork(DbContextOptions<ApplicationContext> options)
        {
            db = new ApplicationContext(options);
            //userManager = new ApplicationUserManager(new UserStore<User>(db));
            //roleManager = new ApplicationRoleManager(new RoleStore<Role>(db));
            //clientManager = new ClientManager(db);
        }

        public EFUnitOfWork()
        {
        }

        /*
public IRepository<User> Users
{
   get
   {
       if (userRepository == null)
           userRepository = new UserRepository(db);
       return userRepository;
   }
}
public IRepository<Role> Roles
{
   get
   {
       if (roleRepository == null)
           roleRepository = new RoleRepository(db);
       return roleRepository;
   }
}*/
        public IRepository<ClientProfile> ClientProfiles
        {
            get
            {
                if (clientProfileRepository == null)
                    clientProfileRepository = new ClientProfileRepository(db);
                return clientProfileRepository;
            }
        }

        public IRepository<Mark> Marks
        {
            get
            {
                if (markRepository == null)
                    markRepository = new MarkRepository(db);
                return markRepository;
            }
        }
        public IRepository<Model> Models
        {
            get
            {
                if (modelRepository == null)
                    modelRepository = new ModelRepository(db);
                return modelRepository;
            }
        }
        public IRepository<Auto> Autos
        {
            get
            {
                if (autoRepository == null)
                    autoRepository = new AutoRepository(db);
                return autoRepository;
            }
        }
        public IRepository<Attachment> Attachments
        {
            get
            {
                if (attachmentRepository == null)
                    attachmentRepository = new AttachmentRepository(db);
                return attachmentRepository;
            }
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
