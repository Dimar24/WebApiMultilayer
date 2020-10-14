using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    public class ClientProfileRepository : IRepository<ClientProfile>
    {
        private ApplicationContext db;

        public ClientProfileRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(ClientProfile item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClientProfile Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ClientProfile item)
        {
            throw new NotImplementedException();
        }
    }
}
