using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Post:Entity
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string ImagePath { get; set; }
        public string ImageBase64 { get; set; }

        public virtual User Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CategoryPost> Categories { get; set; }
    }
}
