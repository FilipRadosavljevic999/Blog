using Application.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCaseController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UseCaseController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<UseCaseController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetUseCaseLog query)
        {
            return Ok(_handler.HandleQuery(query, 0));
        }

        // GET api/<UseCaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UseCaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UseCaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UseCaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
