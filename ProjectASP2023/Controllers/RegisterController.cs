using Application.Command;
using Application.DTO;
using DataAccess;
using Domain.Model;
using Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UseCaseHandler _handler;

        public RegisterController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<RegisterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterDTO value,[FromServices] IRegisterCommand command)
        {
            _handler.HandleCommand(command, value);
            return NoContent();
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
