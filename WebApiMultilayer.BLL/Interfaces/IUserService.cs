using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Infrastructure;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        //Task<OperationDetails> Create(UserDTO userDto);
        ClaimsIdentity Authenticate(UserDTO userDto, UserManager<User> managerUser, RoleManager<IdentityRole> managerRole);
        OperationDetails Create(UserDTO userDto, UserManager<User> managerUser, RoleManager<IdentityRole> managerRole);
        //IEnumerable<ClaimsIdentity> Authenticate();
        //Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
