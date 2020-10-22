
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
    public class ModelService : IService<ModelDTO>
    {
        IUnitOfWork Database { get; set; }

        public ModelService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ModelDTO Get(int id)
        {
            Model model = Database.Models.Get(id);

            if (model == null)
                return null;

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model, ModelDTO>();
                cfg.CreateMap<Mark, MarkDTO>();
            }).CreateMapper();
            return mapper.Map<Model, ModelDTO>(Database.Models.Get(id));
        }

        public IEnumerable<ModelDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => 
            { 
                cfg.CreateMap<Model, ModelDTO>();
                cfg.CreateMap<Mark, MarkDTO>();
            }).CreateMapper();
            
            return mapper.Map<IEnumerable<Model>, List<ModelDTO>>(Database.Models.GetAll());
        }

        public bool Create(ModelDTO item)
        {
            Model model = Database.Models.Get(item.Id);

            if (model != null)
                return false;

            model = new Model
            {
                Name = item.Name,
                MarkId = item.MarkId
            };
            Database.Models.Create(model);
            Database.Save();
            return true;
        }

        public bool Update(ModelDTO item)
        {
            Model model = Database.Models.Get(item.Id);

            if (model == null)
                return false;

            model = new Model
            {
                Id = item.Id,
                Name = item.Name,
                MarkId = item.MarkId
            };

            Database.Models.Update(model);
            Database.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Model model = Database.Models.Get(id);

            if (model == null)
                return false;

            Database.Models.Delete(id);
            Database.Save();
            return true;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
