using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ShowPostDto:BaseDTO
    {
        public int IdPost { get; set; }
        public string Text { get; set; }
        public string ImagePostPath { get; set; }
        public string UserPost { get; set; }
        public List<string> Category { get; set; }
    }
}
