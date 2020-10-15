using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Infrastructure;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;

namespace WebApiMultilayer.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto, UserManager<User> managerUser, RoleManager<IdentityRole> managerRole)
        {

            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await managerUser.FindByEmailAsync(userDto.Email);
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userDto.UserName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // авторизуем его и возвращаем объект ClaimsIdentity
            return id;
        }

        public async Task<OperationDetails> Create(UserDTO userDto, UserManager<User> managerUser, RoleManager<IdentityRole> managerRole)
        {
            
            var role = new IdentityRole { Name = "User" };
            await managerRole.CreateAsync(role);

            User user = await managerUser.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.Email };
                var result = await managerUser.CreateAsync(user, userDto.Password);
                //if (result.Errors.Count() > 0)
                    //return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await managerUser.AddToRoleAsync(user, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, NumberPhone = userDto.NumberPhone };
                Database.ClientManager.Create(clientProfile);
                Database.Save();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        OperationDetails IUserService.Create(UserDTO userDto, UserManager<User> managerUser, RoleManager<IdentityRole> managerRole)
        {
            Create(userDto, managerUser, managerRole);
            throw new NotImplementedException();
        }

        ClaimsIdentity IUserService.Authenticate(UserDTO userDto, UserManager<User> managerUser, RoleManager<IdentityRole> managerRole)
        {
            Authenticate(userDto, managerUser, managerRole);
            throw new NotImplementedException();
        }
    }
}
