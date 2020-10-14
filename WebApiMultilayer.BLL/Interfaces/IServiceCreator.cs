using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.DAL;

namespace WebApiMultilayer.BLL.Interfaces
{
    public interface IServiceCreator
    {
        public IUserService CreateUserService(DbContextOptions<ApplicationContext> options);
    }
}
