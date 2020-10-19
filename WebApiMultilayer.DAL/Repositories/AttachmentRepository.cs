using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.DAL.Repositories
{
    public class AttachmentRepository : IRepository<Attachment>
    {
        private ApplicationContext db;

        public AttachmentRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;
        }

        public IEnumerable<Attachment> GetAll()
        {
            return db.Attachments.ToList();
        }

        public Attachment Get(int id)
        {
            return db.Attachments.Find(id);
        }

        public void Create(Attachment item)
        {
            db.Attachments.Add(item);
        }

        public void Update(Attachment item)
        {
            db.Attachments.Update(item);
        }

        public void Delete(int id)
        {
            db.Attachments.Remove(Get(id));
        }
    }
}
