using Application.DTO;
using Application.Queries;
using DataAccess;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Queries
{
    public class EFGetOnePostQuery : IGetOnePostQuery
    {
        private BlogContext _blogContext;

        public EFGetOnePostQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public int Id => 3;

        public string Name => "Get One Post";

        public string Description => throw new NotImplementedException();

        public ShowOnePost Execute(int search)
        {
            var posts = _blogContext.Posts.Where(x => x.IsActive).Include(x => x.Comments).Include(x => x.Author).Include(x => x.Categories).ThenInclude(x => x.Category).Where(x => x.Id == search)
                .Where(x=>x.Comments.Select(x => x.IsActive).Contains(true))
                .Select(x => new ShowOnePost
                {
                    Title = x.Title,
                    ImagePath = x.ImagePath,
                    TextContent = x.TextContent,
                    Username = x.Author.Username,
                    Comments = x.Comments.Where(x=>x.IsActive).ToList(),
                    Categories = x.Categories.Select(x => new Category
                    {
                        Id = x.Id,
                        Name = x.Category.Name,
                        Description = x.Category.Description,

                    }).ToList()
                })
                .FirstOrDefault();
            if(posts == null)
            {
                throw new NullReferenceException();
            }
            return posts;
        }
    }
}
