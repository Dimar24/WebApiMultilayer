using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.EF;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private ProfileInfoRepository profileInfoRepository;

        private MarkRepository markRepository;
        private ModelRepository modelRepository;
        private AutoRepository autoRepository;
        private AttachmentRepository attachmentRepository;

        public EFUnitOfWork(DbContextOptions<ApplicationContext> options)
        {
            db = new ApplicationContext(options);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

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
        }
        public IRepository<ProfileInfo> ProfileInfos
        {
            get
            {
                if (profileInfoRepository == null)
                    profileInfoRepository = new ProfileInfoRepository(db);
                return profileInfoRepository;
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
