using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    class AutoRepository : IRepository<Auto>
    {
        private ApplicationContext db;

        public AutoRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(Auto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Auto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Auto item)
        {
            throw new NotImplementedException();
        }
    }
}
