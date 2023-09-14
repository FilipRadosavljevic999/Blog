using DataAccess;
using Microsoft.AspNetCore.Mvc;
using ProjectASP2023.JWT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JwtManager _jwtManager;

        public AuthController(JwtManager jwtManager)
        {
            _jwtManager = jwtManager;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request,
                         [FromServices] BlogContext context)
        {
            string token = _jwtManager.MakeToken(request.Email, request.Password);

            return Ok(new { token });
        
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
