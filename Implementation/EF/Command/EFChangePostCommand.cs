using Application;
using Application.Command;
using Application.DTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFPostChangeCommand : IChangePostCommand
    {
        private BlogContext _blogContext;
        private IApplicationUser _actor;
        private ChangePostValidator _validator;

        public EFPostChangeCommand(BlogContext blogContext, IApplicationUser actor,ChangePostValidator validationRules)
        {
            _blogContext = blogContext;
            _actor = actor;
            _validator = validationRules;
        }

        public int Id => 6;
       
        public string Name => "Change Post Command";

        public string Description => throw new NotImplementedException();

        public void Execute(List<object> request)
        {
            var id=Convert.ToInt16(request[0]);
            var postDto = request[1] as ChangePostDTO;
            if(postDto == null)
            {
                throw new NullReferenceException();
            }
            _validator.ValidateAndThrow(postDto);
            var post = _blogContext.Posts.FirstOrDefault(x => x.Id == id && x.IsActive && x.Author.Id==_actor.Id);
            if (post == null)
            {
                throw new NullReferenceException();
            }
          //  var changepost = _blogContext.Posts.Find((short)id);
            post.Title = postDto.Title;
            post.TextContent = postDto.TextContent;
            _blogContext.SaveChanges();
        }
    }
}
