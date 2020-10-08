using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    class ProfileInfoRepository : IRepository<ProfileInfo>
    {
        private ApplicationContext db;

        public ProfileInfoRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(ProfileInfo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProfileInfo Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfileInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProfileInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
