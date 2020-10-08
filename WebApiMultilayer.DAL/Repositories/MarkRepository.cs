using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    class MarkRepository : IRepository<Mark>
    {
        private ApplicationContext db;

        public MarkRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(Mark item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Mark Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mark> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Mark item)
        {
            throw new NotImplementedException();
        }
    }
}
