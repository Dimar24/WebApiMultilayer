using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiMultilayer.BLL.DTO;

namespace WebApiMultilayer.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(UserDTO model);
        Task<bool> Login(UserDTO model);
        Task Logout();
    }
}
