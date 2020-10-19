using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    public class MarkRepository : IRepository<Mark>
    {
        private ApplicationContext db;

        public MarkRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public IEnumerable<Mark> GetAll()
        {
            return db.Marks.ToList();
        }

        public Mark Get(int id)
        {
            return db.Marks.Find(id);
        }

        public void Create(Mark item)
        {
            db.Marks.Add(item);
        }

        public void Update(Mark item)
        {
            db.Marks.Update(item);
        }

        public void Delete(int id)
        {
            db.Marks.Remove(Get(id));
        }
    }
}
