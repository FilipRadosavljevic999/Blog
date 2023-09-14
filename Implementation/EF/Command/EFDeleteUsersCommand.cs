using Application.Command;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFDeleteUsersCommand : IDeleteUsersCommand
    {
        private BlogContext _blogContext;

        public EFDeleteUsersCommand(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public int Id => 14;

        public string Name => "DeleteUsers";

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
             var user = _blogContext.Users.Find(request);
            if (user == null)
            {
                throw new NullReferenceException();
            }
            user.IsActive = false;
            _blogContext.SaveChanges();
        }
    }
}
