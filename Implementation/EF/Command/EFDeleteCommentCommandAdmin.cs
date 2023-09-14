using Application.Command;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFDeleteCommentCommandAdmin : IDeleteCommentCommandAdmin
    {
        private BlogContext _context;

        public EFDeleteCommentCommandAdmin(BlogContext context)
        {
            _context = context;
        }

        public int Id => 11;

        public string Name => "Delete Command";

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
            var comment = _context.Comments.Find(request);
            if (comment == null)
            {
                throw new NullReferenceException();
            }
            comment.IsActive = false;
            _context.SaveChanges();
        }
    }
}
