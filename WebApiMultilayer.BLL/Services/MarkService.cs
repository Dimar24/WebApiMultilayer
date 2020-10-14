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

        public void Create(MarkDTO item)
        {
            Mark mark = Database.Marks.Get(item.Id);
            
            if(mark != null)
                throw new NotImplementedException();
            mark = new Mark
            {
                Name = item.Name
            };
            Database.Marks.Create(mark);
            Database.Save();
        }

        public void Delete(int id)
        {
            Mark mark = Database.Marks.Get(id);

            if (mark == null)
                throw new NotImplementedException();

            Database.Marks.Delete(id);
            Database.Save();
        }

        public MarkDTO Get(int id)
        {
            Mark mark = Database.Marks.Get(id);

            if (mark == null)
                throw new NotImplementedException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Mark, MarkDTO>()).CreateMapper();
            return mapper.Map<Mark, MarkDTO>(Database.Marks.Get(id));
        }

        public IEnumerable<MarkDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Mark, MarkDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Mark>, List<MarkDTO>>(Database.Marks.GetAll());
        }

        public void Update(MarkDTO item)
        {
            Mark mark = Database.Marks.Get(item.Id);

            if (mark == null)
                throw new NotImplementedException();
            mark = new Mark
            {
                Id = item.Id,
                Name = item.Name
            };

            Database.Marks.Update(mark);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
