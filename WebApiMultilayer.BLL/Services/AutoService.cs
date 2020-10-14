using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    class AutoService : IService<Auto>
    {
        IUnitOfWork Database { get; set; }

        public AutoService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(Auto item)
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
