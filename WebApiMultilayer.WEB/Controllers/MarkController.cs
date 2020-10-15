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
    public class MarkController : ControllerBase
    {
        IService<MarkDTO> _service;
        private readonly ILogger<MarkController> _logger;

        public MarkController(ILogger<MarkController> logger, IService<MarkDTO> service)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<MarkController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get Marks");
            return Ok(_service.GetAll());
        }

        // GET api/<MarkController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Get Mark: {0}", HttpContext.Request);
            return Ok(_service.Get(id));
        }

        // POST api/<MarkController>
        [HttpPost]
        public IActionResult Post([FromBody] MarkDTO markDTO)
        {
            _logger.LogInformation("Add Mark: {0}", HttpContext.Request);
            _service.Create(markDTO);
            return Ok();
        }

        // PUT api/<MarkController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MarkDTO markDTO)
        {
            _logger.LogInformation("Update Mark: {0}", HttpContext.Request);
            markDTO.Id = id;
            _service.Update(markDTO);
            return Ok();
        }

        // DELETE api/<MarkController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Delete Mark: {0}", HttpContext.Request);
            _service.Delete(id);
            return Ok();
        }
    }
}
