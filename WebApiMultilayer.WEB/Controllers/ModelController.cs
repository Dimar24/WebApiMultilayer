using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiMultilayer.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModelController : ControllerBase
    {
        IService<ModelDTO> _service;
        private readonly ILogger<ModelController> _logger;

        public ModelController(ILogger<ModelController> logger, IService<ModelDTO> service)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<ModelController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get Models");
            return Ok(_service.GetAll());
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Get Model: {0}", HttpContext.Request);
            return Ok(_service.Get(id));
        }

        // POST api/<ModelController>
        [HttpPost]
        public IActionResult Post([FromBody] ModelDTO modelDTO)
        {
            _logger.LogInformation("Add Model: {0}", HttpContext.Request);
            if (_service.Create(modelDTO))
                return Ok();
            return BadRequest();
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ModelDTO modelDTO)
        {
            _logger.LogInformation("Update Model: {0}", HttpContext.Request);
            modelDTO.Id = id;;
            if (_service.Update(modelDTO))
                return Ok();
            return BadRequest();
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Delete Model: {0}", HttpContext.Request);
            if (_service.Delete(id))
                return Ok();
            return BadRequest();
        }
    }
}
