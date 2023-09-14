using Application.Command;
using Application.DTO;
using DataAccess;
using Domain.Model;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private UseCaseHandler _handler;
        // GET: api/<CommentController>
      
        

        public CommentController(UseCaseHandler handler)
        {
            _handler = handler;
        }
       
       
      
        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto value,[FromServices] IAddCommentCommand command)
        {
            _handler.HandleCommand(command, value);
            return NoContent();
        }

        
      

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommenCommand commenCommand)
        {
         
            _handler.HandleCommand(commenCommand, id);
            return NoContent();
        }
    }
}
