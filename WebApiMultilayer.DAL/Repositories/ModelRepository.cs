using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    class ModelRepository : IRepository<Model>
    {
        private ApplicationContext db;

        public ModelRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(Entities.Model item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entities.Model Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Model item)
        {
            throw new NotImplementedException();
        }
    }
}
