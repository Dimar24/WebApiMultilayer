using AutoMapper;
using System;
using System.Collections.Generic;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    public class MarkService : IService<MarkDTO>
    {
        IUnitOfWork Database { get; set; }

        public MarkService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public MarkDTO Get(int id)
        {
            Mark mark = Database.Marks.Get(id);

            if (mark == null)
                return null;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Mark, MarkDTO>()).CreateMapper();
            return mapper.Map<Mark, MarkDTO>(Database.Marks.Get(id));
        }

        public IEnumerable<MarkDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Mark, MarkDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Mark>, List<MarkDTO>>(Database.Marks.GetAll());
        }

        public bool Create(MarkDTO item)
        {
            if (item != null)
                return false;

            Mark mark = Database.Marks.Get(item.Id);

            if (mark != null)
                return false;

            mark = new Mark
            {
                Name = item.Name
            };
            Database.Marks.Create(mark);
            Database.Save();
            return true;
        }

        public bool Update(MarkDTO item)
        {
            Mark mark = Database.Marks.Get(item.Id);

            if (mark == null)
                return false;

            mark = new Mark
            {
                Id = item.Id,
                Name = item.Name
            };

            Database.Marks.Update(mark);
            Database.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Mark mark = Database.Marks.Get(id);

            if (mark == null)
                return false;

            Database.Marks.Delete(id);
            Database.Save();
            return true;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
