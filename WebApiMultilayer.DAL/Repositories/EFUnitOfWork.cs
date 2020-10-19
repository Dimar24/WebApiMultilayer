using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;

        private MarkRepository markRepository;
        private ModelRepository modelRepository;
        private AutoRepository autoRepository;
        private AttachmentRepository attachmentRepository;

        public EFUnitOfWork(DbContextOptions<ApplicationContext> options, UserManager<User> _userManager, 
            RoleManager<IdentityRole> _roleManager, SignInManager<User> _signInManager)
        {
            db = new ApplicationContext(options);
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            //clientManager = new ClientManager(db);
        }

        public EFUnitOfWork()
        {
        }

        public UserManager<User> Users { get { return userManager; } }
       /* {
           get
           {
               if (userRepository == null)
                   userRepository = new UserRepository(db);
               return userRepository;
           }
        }*/
        public RoleManager<IdentityRole> Roles { get { return roleManager; } }

        public SignInManager<User> SignIn { get { return signInManager; } }

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
