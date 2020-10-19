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

        public async Task<bool> Register(UserDTO model)
        {
            var user = await Database.Users.FindByEmailAsync(model.Email);
            if (user == null)
            {
                user = new User { Email = model.Email, UserName = model.UserName, PhoneNumber = model.NumberPhone };

                var checkAdd = await Database.Users.CreateAsync(user, model.Password);

                var userRole = await Database.Roles.FindByNameAsync("user");

                if (userRole == null)
                {
                    await Database.Roles.CreateAsync(new IdentityRole("user"));
                    userRole = await Database.Roles.FindByNameAsync("user");
                }

                await Database.Users.AddToRoleAsync(user, userRole.Name);

                if (checkAdd.Succeeded)
                {
                    await Database.SignIn.SignInAsync(user, false);
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> Login(UserDTO model)
        {
            var user = await Database.Users.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var checkPassword = await Database.SignIn.CheckPasswordSignInAsync(user, model.Password, false);

                if (checkPassword.Succeeded)
                {
                    await Database.SignIn.SignInAsync(user, false);
                    return true;
                }
            }
            return false;

        }

        public async Task Logout()
        {
            await Database.SignIn.SignOutAsync();
        }
    }
}
