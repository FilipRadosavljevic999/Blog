using Application;
using Application.Command;
using Application.DTO;
using Application.Uploader;
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
    public class EFAddPostCommand : IAddPostCommand
    {
        private BlogContext _blogContext;
        private IApplicationUser actor;
        private PostValidatior _postValidator;
        private IBase64FileUploader _uploader;
        public EFAddPostCommand(BlogContext blogContext, IApplicationUser actor,PostValidatior validationRules, IBase64FileUploader uploader)
        {
            _blogContext = blogContext;
            this.actor = actor;
            _postValidator = validationRules;
            _uploader = uploader;
        }

        public int Id => 4;

        public string Name => "Add post";

        public string Description => throw new NotImplementedException();

        public void Execute(PostDTO request)
        {
            _postValidator.ValidateAndThrow(request);
            var user=_blogContext.Users.FirstOrDefault(x=>x.Id==actor.Id);
            if (user == null)
            {
                throw new NullReferenceException();
            }
            Post post = new Post();
            post.Title = request.Title;
            post.TextContent = request.TextContent;
            post.Author = user;
            post.ImagePath = request.ImagePath;
            post.ImageBase64 = request.ImagePath;
            _blogContext.Posts.Add(post);
            List<CategoryPost> categoryPosts = new List<CategoryPost>();
            foreach (var item in request.CategoryIds)
            {
                CategoryPost categoryPost = new CategoryPost();
                categoryPost.Post = post;
                categoryPost.Category = _blogContext.Categories.Where(x => x.Id == item).First();
                categoryPosts.Add(categoryPost);
            }
            _uploader.Upload(request.ImagePath);
            _blogContext.CategoriesPost.AddRange(categoryPosts);
            _blogContext.SaveChanges();
        }
    }
}
