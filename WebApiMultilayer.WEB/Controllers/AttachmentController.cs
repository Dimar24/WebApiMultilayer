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
    public class AttachmentController : ControllerBase
    {
        IService<AttachmentDTO> _service;
        private readonly ILogger<MarkController> _logger;

        public AttachmentController(ILogger<MarkController> logger, IService<AttachmentDTO> service)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<AttachmentController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get Attachments");
            return Ok(_service.GetAll());
        }

        // GET api/<AttachmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Get Attachment: {0}", HttpContext.Request);
            return Ok(_service.Get(id));
        }

        // POST api/<AttachmentController>
        [HttpPost]
        public IActionResult Post([FromBody] AttachmentDTO attachmentDTO)
        {
            _logger.LogInformation("Add Mark: {0}", HttpContext.Request);
            if (_service.Create(attachmentDTO))
                return Ok();
            return BadRequest();
        }

        // PUT api/<AttachmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AttachmentDTO attachmentDTO)
        {
            _logger.LogInformation("Update Mark: {0}", HttpContext.Request);
            attachmentDTO.Id = id;
            if (_service.Update(attachmentDTO))
                return Ok();
            return BadRequest();
        }

        // DELETE api/<AttachmentController>/5
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
