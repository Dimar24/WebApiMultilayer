using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.EF;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    class RoleRepository : IRepository<Role>
    {
        private ApplicationContext db;

        public RoleRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(Role item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
