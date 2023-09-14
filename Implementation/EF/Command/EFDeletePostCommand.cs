using Application;
using Application.Command;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFDeletePostCommand : IDeletePostCommand
    {
        private BlogContext _blogContext;
        private IApplicationUser _actor;

        public EFDeletePostCommand(BlogContext blogContext, IApplicationUser actor)
        {
            _blogContext = blogContext;
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "Delete post";

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
            var post = _blogContext.Posts.FirstOrDefault(x=>x.Id==request && x.Author.Id==_actor.Id);
            if (post == null)
            {
                throw new NullReferenceException();
            }
            post.IsActive = false;
            _blogContext.SaveChanges();
        }
    }
}
