using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    public class AutoRepository : IRepository<Auto>
    {
        private ApplicationContext db;

        public AutoRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public Auto Get(int id)
        {
            Auto auto = db.Autos.Include(m => m.Model).ThenInclude(m => m.Mark).Include(u => u.User).FirstOrDefault(m => m.Id == id);
            // model = db.Models.Include(m => m.Mark).FirstOrDefault(m => m.Id == id);
            //db.Entry(auto).Reference(m => m.Model).Load();
            //db.Entry(auto).Reference(m => m.Model.Mark).Load();
            //db.Entry(auto).Reference(u => u.User).Load();
            return auto;
        }

        public IEnumerable<Auto> GetAll()
        {
            return db.Autos.Include(m => m.Model).ThenInclude(m => m.Mark).Include(u => u.User).ToList();
        }

        public void Create(Auto item)
        {
            db.Autos.Add(item);
        }

        public void Update(Auto item)
        {
            db.Autos.Update(item);
        }

        public void Delete(int id)
        {
            db.Autos.Remove(Get(id));
        }
    }
}
