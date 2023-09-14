using Application.DTO;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Queries
{
    public class EFGetPostQuery : IGetPostQuery
    {
        public int Id => 2;

        public string Name => "Get Posts";

        private BlogContext _blogContext;

        public EFGetPostQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public string Description => "Get all post";

        public PagedResponse<ShowPostDto> Execute(SearchPostDTO dto)
        {
            var query = _blogContext.Posts.Where(x=>x.IsActive).Include(x => x.Author).Include(x=>x.Categories).ThenInclude(x=>x.Post).Where(x => x.Comments.Select(x => x.IsActive).Contains(true)).AsQueryable();
            if (!String.IsNullOrEmpty(dto.KeyWord))
            {
                query = query.Where(x => x.Title.Contains(dto.KeyWord) || x.TextContent.Contains(dto.KeyWord));
            }

            if (dto.PerPage == 0 || dto.PerPage < 1)
            {
                dto.PerPage = 3;
            }

            if (dto.Page == 0 || dto.Page < 1)
            {
                dto.Page = 1;
            }
            
            var toSkip = (dto.Page - 1) * dto.PerPage;
            var response = new PagedResponse<ShowPostDto>();
            //response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(dto.PerPage).Select(x => new ShowPostDto
            {
                Text = x.TextContent,
                ImagePostPath = x.ImagePath,
                UserPost = x.Author.Username,
                IdPost = x.Id,
                Category=x.Categories.Select(x => x.Category.Name).ToList(),
            }).ToList();
            return response;
        }
    }
}
