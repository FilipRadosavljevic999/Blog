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
    public class CommentAdminController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CommentAdminController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<CommentAdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommentAdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommentAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentAdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommentCommandAdmin command)
        {
            _handler.HandleCommand(command, id);
            return Ok();
        }
    }
}
