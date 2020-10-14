using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    class RoleService : IService<Role>
    {
        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Role item)
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
