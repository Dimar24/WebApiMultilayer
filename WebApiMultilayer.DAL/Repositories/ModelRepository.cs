using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    public class ModelRepository : IRepository<Model>
    {
        private ApplicationContext db;

        public ModelRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public void Create(Model item)
        {
            db.Models.Add(item);
        }

        public void Delete(int id)
        {
            db.Models.Remove(Get(id));
        }

        public Model Get(int id)
        {
            return db.Models.Find(id);
        }

        public IEnumerable<Model> GetAll()
        {
            return db.Models.ToList();
        }

        public void Update(Model item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
