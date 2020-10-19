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
    public class AutoController : ControllerBase
    {
        IService<AutoDTO> _service;
        private readonly ILogger<MarkController> _logger;

        public AutoController(ILogger<MarkController> logger, IService<AutoDTO> service)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<AutoController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get Marks");
            return Ok(_service.GetAll());
        }

        // GET api/<AutoController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Get Mark: {0}", HttpContext.Request);
            return Ok(_service.Get(id));
        }

        // POST api/<AutoController>
        [HttpPost]
        public IActionResult Post([FromBody] AutoDTO autoDTO)
        {
            _logger.LogInformation("Add Mark: {0}", HttpContext.Request);
            if (_service.Create(autoDTO))
                return Ok();
            return BadRequest();
        }

        // PUT api/<AutoController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AutoDTO autoDTO)
        {
            _logger.LogInformation("Update Mark: {0}", HttpContext.Request);
            autoDTO.Id = id;
            if (_service.Update(autoDTO))
                return Ok();
            return BadRequest();
        }

        // DELETE api/<AutoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Delete Mark: {0}", HttpContext.Request);
            if (_service.Delete(id))
                return Ok();
            return BadRequest();
        }
    }
}
