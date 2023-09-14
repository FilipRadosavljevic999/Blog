using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ShowOnePost:BaseDTO
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string ImagePath { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Category> Categories { get; set; }

    }
}
