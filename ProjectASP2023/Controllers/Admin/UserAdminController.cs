using Application.Command;
using Application.DTO.AdminDTO;
using Application.Queries;
using DataAccess;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAdminController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UserAdminController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<UserAdminController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetUsersAdminQuery query)
        {
           
            return Ok(_handler.HandleQuery(query,0));
        }

        // GET api/<UserAdminController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<UserAdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices]IDeleteUsersCommand command)
        {
           /* var user = _blogContext.Users.Find(id);
            if (user == null)
            {
                throw new NullReferenceException();
            }
            user.IsActive = false;
            _blogContext.SaveChanges();*/
           _handler.HandleCommand(command,id);
            return Ok();
        }
    }
}
