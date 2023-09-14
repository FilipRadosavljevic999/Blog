using Application.Command;
using Application.DTO;
using Application.Queries;
using DataAccess;
using Domain.Model;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        // GET: api/<PostController>
        private UseCaseHandler _handler;
        private BlogContext _blogContext;
        public PostController(UseCaseHandler handler,BlogContext blog)
        {
            _handler = handler;
            _blogContext = blog;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] SearchPostDTO dto,[FromServices] IGetPostQuery query)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id,[FromServices] IGetOnePostQuery query)
        {
            
            return Ok(_handler.HandleQuery(query,id));
        }

        // POST api/<PostController>
        [HttpPost]
        public IActionResult Post([FromBody] PostDTO postDTO,[FromServices] IAddPostCommand command)
        {
            _handler.HandleCommand(command,postDTO);
            return NoContent();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangePostDTO postDto,[FromServices] IChangePostCommand command)
        {
            List<object> list=new List<object> { id,postDto};
            _handler.HandleCommand(command,list);
           
            return NoContent();
            

        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePostCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
