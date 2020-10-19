using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    public class AttachmentService : IService<AttachmentDTO>
    {
        IUnitOfWork Database { get; set; }

        public AttachmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public AttachmentDTO Get(int id)
        {
            Attachment attachment = Database.Attachments.Get(id);

            if (attachment == null)
                return null;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Attachment, AttachmentDTO>()).CreateMapper();
            return mapper.Map<Attachment, AttachmentDTO>(Database.Attachments.Get(id));
        }

        public IEnumerable<AttachmentDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Model, ModelDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Attachment>, List<AttachmentDTO>>(Database.Attachments.GetAll());
        }

        public bool Create(AttachmentDTO item)
        {
            Attachment attachment = Database.Attachments.Get(item.Id);

            if (attachment != null)
                return false;

            attachment = new Attachment
            {
                Path = item.Path,
                AutoId = item.AutoId
            };
            Database.Attachments.Create(attachment);
            Database.Save();
            return true;
        }

        public bool Update(AttachmentDTO item)
        {
            //update for images?????
            return true;
        }

        public bool Delete(int id)
        {
            Attachment attachment = Database.Attachments.Get(id);

            if (attachment == null)
                return false;

            Database.Attachments.Delete(id);
            Database.Save();
            return true;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
