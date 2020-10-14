using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    class AttachmentService : IService<Attachment>
    {
        IUnitOfWork Database { get; set; }

        public AttachmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(Attachment item)
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
