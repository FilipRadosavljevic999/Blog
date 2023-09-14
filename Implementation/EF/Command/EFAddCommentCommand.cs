using Application;
using Application.Command;
using Application.DTO;
using DataAccess;
using Domain.Model;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFAddCommentCommand : IAddCommentCommand
    {
        private BlogContext _blogContext;
        private IApplicationUser _actor;
        private CommentValidator _validaator;
        public EFAddCommentCommand(BlogContext blogContext, IApplicationUser actor, CommentValidator validationRules)
        {
            _blogContext = blogContext;
            _actor = actor;
            _validaator = validationRules;
        }

        public int Id => 7;

        public string Name => "Add Comment";

        public string Description => throw new NotImplementedException();

        public void Execute(CommentDto request)
        {
            _validaator.ValidateAndThrow(request);
            Comment comment = new Comment();
            var post = _blogContext.Posts.Find(request.PostId);
            if (post == null)
            {
                throw new NullReferenceException();
            }
            comment.Post = post;
            comment.Text = request.Comment;
            var user = _blogContext.Users.Where(u => u.Id == _actor.Id).FirstOrDefault();
            if(user == null)
            {
                throw new NullReferenceException();
            }
            comment.Author =user;
            _blogContext.Comments.Add(comment);
            _blogContext.SaveChanges();
        }
    }
}
