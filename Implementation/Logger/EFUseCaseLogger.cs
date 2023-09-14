using Application.Logger;
using DataAccess;
using Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logger
{
    public class EFUseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext _context;

        public EFUseCaseLogger(BlogContext context)
        {
            _context = context;
        }
        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Actor = entry.Actor,
                ActorId = entry.ActorId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                Created = DateTime.UtcNow
            });
            _context.SaveChanges();
        }
    }
}
