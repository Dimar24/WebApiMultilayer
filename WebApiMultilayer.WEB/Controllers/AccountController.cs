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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(ILogger<MarkController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("/reg")]
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO model)
        {
                User user = new User { Email = model.Email, UserName = model.UserName };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
            
            return Ok();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                var checkPassword =
                    await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (checkPassword.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                }
            }
 
            return Ok();
        }

        [Route("/logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        // GET: api/<AccountController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get");
            return Ok();

            _logger.LogInformation("Get");
            return Ok(/*_service.GetAll()*/);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Get: {0}", HttpContext.Request);
            return Ok(/*_service.Get(id)*/);
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation("Add: {0}", HttpContext.Request);
            //_service.Create(userDTO);
            return Ok();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UserDTO userDTO)
        {
            _logger.LogInformation("Update: {0}", HttpContext.Request);
            userDTO.Id = id;
            //Authenticate(userDTO);
            //_service.Update(markDTO);
            return Ok();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
