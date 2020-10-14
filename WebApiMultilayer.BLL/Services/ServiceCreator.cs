using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Repositories;

namespace WebApiMultilayer.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(DbContextOptions<ApplicationContext> options)
        {
            return new UserService(new EFUnitOfWork(options));
        }
    }
}
