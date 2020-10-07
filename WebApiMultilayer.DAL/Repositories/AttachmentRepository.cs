using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.DAL.EF;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    class AttachmentRepository : IRepository<Attachment>
    {
        private ApplicationContext db;

        public AttachmentRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(Attachment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Attachment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attachment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Attachment item)
        {
            throw new NotImplementedException();
        }
    }
}
