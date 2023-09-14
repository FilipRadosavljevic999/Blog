using Application.Command;
using DataAccess;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostAdminController : ControllerBase
    {
        // GET: api/<PostAdminController>
        private UseCaseHandler _handler;

        public PostAdminController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PostAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PostAdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PostAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostAdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePostAdmin deletePostAdmin)
        {
            _handler.HandleCommand(deletePostAdmin, id);
           
            return NoContent();
        }
    }
}
