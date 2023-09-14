using Application.Command;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFDeletePostCommandAdmin : IDeletePostAdmin
    {
        private BlogContext _blogContext;
        public int Id => 12;

        public string Name => "Delete";

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
            var post = _blogContext.Posts.Find(request);
            if (post == null)
            {
                throw new NullReferenceException();
            }
            post.IsActive = false;
            _blogContext.SaveChanges();
        }
    }
}
