using Leilao.Domain.Dtos.User;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Leilao.Application.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class usersController : Controller
    {
        private IUserService _service;

        public usersController(IUserService service)
        {
            _service = service;
        }
                
        [HttpGet("{id}", Name = "GetUserWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var validaton = await _service.Validation(dtoCreate);
                if (!validaton.Sucess)
                {
                    return StatusCode((int)HttpStatusCode.Found, validaton.Message);
                }

                var result = await _service.Post(dtoCreate);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetUserWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
                
        [HttpPut("{id}", Name = "GetUserWithId")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UserDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                if (!result.Id.Equals(dtoUpdate.Id))
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Id nao informado.");
                }

                var validaton = await _service.Validation(dtoUpdate, id);
                if (!validaton.Sucess)
                {
                    return StatusCode((int)HttpStatusCode.Found, validaton.Message);
                }

                return Ok(await _service.Put(dtoUpdate));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
                
        [HttpDelete("{id}", Name = "GetUserWithId")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
