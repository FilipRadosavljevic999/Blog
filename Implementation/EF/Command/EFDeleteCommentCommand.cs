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
    public class EFDeleteCommentCommand : IDeleteCommenCommand
    {
        private BlogContext _blogContext;
        private IApplicationUser _actor;

        public EFDeleteCommentCommand(BlogContext blogContext, IApplicationUser actor)
        {
            _blogContext = blogContext;
            _actor = actor;
        }

        public int Id => 8;

        public string Name => "Delete comment";

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
            var comment= _blogContext.Comments.FirstOrDefault(x=>x.Id==request && x.AuthorId==_actor.Id);
            if(comment == null)
            {
                throw new NullReferenceException();
            }
            comment.IsActive = false;
            _blogContext.SaveChanges();
        }
    }
}
