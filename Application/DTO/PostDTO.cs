using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PostDTO:BaseDTO
    {
        public List<int> CategoryIds { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string ImagePath { get; set; }
    }
}
