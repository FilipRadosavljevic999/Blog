using DataAccess;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectASP2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        
        // GET: api/<TestController>
        [HttpGet]
        public IActionResult Get([FromServices] BlogContext context)
        {
            List<Role> roles= new List<Role>();
            List<User> users= new List<User>();
          //  List<RoleUseCase> roleUseCases= new List<RoleUseCase>();
            List<Category> categories= new List<Category>();
            List<Post> posts= new List<Post>();
            List<Comment> comments= new List<Comment>();    
            List<CategoryPost> categoriesPost= new List<CategoryPost>();
            for(var i = 0; i < 10; i++)
            {
                Category category = new Category();
                category.Name = "Category"+i;
                category.Description = "TestDescription";

                categories.Add(category);
            }
           
       
            Role role= new Role();
            role.Name = "User";
            role.IsActive= true;
            roles.Add(role);
            Role Roleadmin=new Role();
            Roleadmin.Name = "Admin";
            roles.Add(Roleadmin);
            User u= new User();
            u.FirstName = "Filip";
            u.LastName = "Mikic";
            u.Username = "Filip12345";
            u.Email = "Filip@gmail.com";
            u.Password= BCrypt.Net.BCrypt.HashPassword("password123"); ;
            u.Role = roles.ElementAt(0);
            users.Add(u);
            User us = new User();
            us.FirstName = "Filip";
            us.LastName = "Mikic";
            us.Username = "Admin12345";
            us.Email = "Admin@gmail.com";
            us.Password = BCrypt.Net.BCrypt.HashPassword("password123");
            us.Role = roles.ElementAt(1);
            users.Add(us);

            for (var i = 0; i < 10; i++)
            {
                Post post = new Post();
                post.Title = "Title " + i;
                post.TextContent = "Content " + i;
                post.ImagePath = $"Test{i}.jpg";
                post.Author = users.ElementAt(0);
                posts.Add(post);

            }
            for (var i = 0; i < 10; i++)
            {
                CategoryPost catpost = new CategoryPost();
                catpost.Post=posts.ElementAt(i);
                catpost.Category=categories.ElementAt(i);

                categoriesPost.Add(catpost);

            }
            for (var i = 0; i < 10; i++)
            {
                Comment comment = new Comment();
                comment.Text = "Comment " + i;
                comment.Post = posts.ElementAt(i);
                comment.Author = users.ElementAt(0);
                comments.Add(comment);
            }
           
            /*RoleUseCase roleUseCase= new RoleUseCase();
            roleUseCase.UseCaseId = 1;
            roleUseCase.Role=roles.ElementAt(0);
            roleUseCases.Add(roleUseCase);
            roleUseCase.UseCaseId = 2;
            roleUseCase.Role = roles.ElementAt(0);
            roleUseCases.Add(roleUseCase);
            roleUseCase.UseCaseId = 3;
            roleUseCase.Role = roles.ElementAt(1);
            roleUseCases.Add(roleUseCase);
            roleUseCase.UseCaseId = 4;
            roleUseCase.Role = roles.ElementAt(1);
            roleUseCases.Add(roleUseCase);*/
             
            context.Roles.AddRange(roles);
            context.Users.AddRange(users);
           // context.RoleUseCases.AddRange(roleUseCases);
            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Comments.AddRange(comments);
            context.CategoriesPost.AddRange(categoriesPost);
            context.SaveChanges();
            return Ok();
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
