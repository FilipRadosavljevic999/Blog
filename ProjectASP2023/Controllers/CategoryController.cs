using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        private BlogContext _blogContext;

        public CategoryController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
          var categories=_blogContext.Categories.ToList();
            return Ok(categories);
        }

        
        
    }
}
