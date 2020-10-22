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
    public class AutoService : IService<AutoDTO>
    {
        IUnitOfWork Database { get; set; }

        public AutoService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public AutoDTO Get(int id)
        {
            Auto auto = Database.Autos.Get(id);

            if (auto == null)
                return null;

            var mapper = new MapperConfiguration(cfg => 
                {
                    cfg.CreateMap<Model, ModelDTO>();
                    cfg.CreateMap<Mark, MarkDTO>();
                    cfg.CreateMap<Auto, AutoDTO>();
                    cfg.CreateMap<User, UserDTO>();
                }).CreateMapper();
            return mapper.Map<Auto, AutoDTO>(auto);
        }

        public IEnumerable<AutoDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Auto, AutoDTO>();
                cfg.CreateMap<Model, ModelDTO>();
                cfg.CreateMap<Mark, MarkDTO>();
                cfg.CreateMap<User, UserDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Auto>, List<AutoDTO>>(Database.Autos.GetAll());
        }

        public bool Create(AutoDTO item)
        {
            Auto auto = Database.Autos.Get(item.Id);

            if (auto != null)
                return false;

            auto = new Auto
            {
                Color = item.Color,
                EnginyCapacity = item.EnginyCapacity,
                EnginyType = item.EnginyType,
                Transmition = item.Transmition,
                Location = item.Location,
                MaxSpeed = item.MaxSpeed,
                Year = item.Year,
                Price = item.Price,
                ModelId = item.ModelId,
                UserId = item.UserId
            };
            Database.Autos.Create(auto);
            Database.Save();
            return true;
        }

        public bool Update(AutoDTO item)
        {
            Auto auto = Database.Autos.Get(item.Id);

            if (auto != null)
                return false;

            auto = new Auto
            {
                Color = item.Color,
                EnginyCapacity = item.EnginyCapacity,
                EnginyType = item.EnginyType,
                Transmition = item.Transmition,
                Location = item.Location,
                MaxSpeed = item.MaxSpeed,
                Year = item.Year,
                Price = item.Price,
                ModelId = item.ModelId,
                UserId = item.UserId
            };

            Database.Autos.Update(auto);
            Database.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Auto auto = Database.Autos.Get(id);

            if (auto == null)
                return false;

            Database.Autos.Delete(id);
            Database.Save();
            return true;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
