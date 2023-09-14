using Application.Queries;
using DataAccess;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Queries
{
    public class EfUseCaseLoggerQuery : IGetUseCaseLog
    {
        private BlogContext _context;

        public EfUseCaseLoggerQuery(BlogContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Get UseCase Log";

        public string Description => throw new NotImplementedException();

        public List<LogEntry> Execute(int search)
        {
            var entries= _context.LogEntries.ToList();
            return entries;
        }
    }
}
