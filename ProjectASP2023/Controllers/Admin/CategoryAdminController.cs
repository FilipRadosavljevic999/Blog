using Application.Command;
using Application.DTO.AdminDTO;
using DataAccess;
using Domain.Model;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryAdminController : ControllerBase
    {
        public UseCaseHandler _handler;

        public CategoryAdminController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<CategoryAdminController>
        [HttpGet]
        public IActionResult Get()
        {
          //  var categories=_blogContext.Categories.Where(x=>x.IsActive).ToList();
            return Ok();
        }

        // GET api/<CategoryAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryAdminController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryAdminDto value,[FromServices] IAddCategoryAdmin command)
        {
            _handler.HandleCommand(command, value);
           
            return NoContent();
        }

        // PUT api/<CategoryAdminController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryAdminDto value,[FromServices] IChangeCategoryAdmin command)
        {
            List<object> list = new List<object>() { id,value};
            _handler.HandleCommand(command, list);  
          
            return NoContent();
        }

        // DELETE api/<CategoryAdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            /*var category = _blogContext.Categories.Find(id);
            if (category == null)
            {
                throw new NullReferenceException();
            }
            category.IsActive = false;
            _blogContext.SaveChanges();*/
            return NoContent();
        }
    }
}
