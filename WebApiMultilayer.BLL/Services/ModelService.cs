using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    class ModelService : IService<Model>
    {
        IUnitOfWork Database { get; set; }

        public ModelService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public Model Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Model item)
        {
            throw new NotImplementedException();
        }

        public void Update(Model item)
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
