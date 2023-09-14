using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CommentDto:BaseDTO
    {
        public string Comment { get; set; }
        public int PostId { get; set; }
    }
}
