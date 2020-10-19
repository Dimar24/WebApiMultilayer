using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;

namespace WebApiMultilayer.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<MarkController> _logger;
        private readonly IUserService _service;


        public AccountController(ILogger<MarkController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [Route("/reg")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
        {
            if (await _service.Register(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserDTO model)
        {
            if (await _service.Login(model))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("/logout")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get");
            return Ok("Hello");
        }
    }
}
