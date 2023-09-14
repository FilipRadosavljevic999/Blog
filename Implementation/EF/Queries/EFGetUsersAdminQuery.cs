using Application.DTO.AdminDTO;
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
    public class EFGetUsersAdminQuery : IGetUsersAdminQuery
    {
        private BlogContext _blogContext;

        public EFGetUsersAdminQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public int Id => 13;

        public string Name => "Get Users";

        public string Description => throw new NotImplementedException();

        public List<ShowUsersAdminDto> Execute(int search)
        {
            var users = _blogContext.Users.Include(x => x.Role).Select(x => new ShowUsersAdminDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Username = x.Username,
                RoleName = x.Role.Name,
                IsActive = x.IsActive,

            }).ToList();
            return users;
        }
    }
}
