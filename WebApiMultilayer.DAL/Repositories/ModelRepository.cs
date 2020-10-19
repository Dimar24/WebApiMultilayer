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

        public IEnumerable<Model> GetAll()
        {
            return db.Models.Include(m => m.Mark).ToList();
        }

        public Model Get(int id)
        {
            Model model = db.Models.Include(m => m.Mark).FirstOrDefault(m => m.Id == id);
            return model;
        }

        public void Create(Model item)
        {
            db.Models.Add(item);
        }

        public void Update(Model item)
        {
            db.Models.Update(item);
        }

        public void Delete(int id)
        {
            db.Models.Remove(Get(id));
        }
    }
}
