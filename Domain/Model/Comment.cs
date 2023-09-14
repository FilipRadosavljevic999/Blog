using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comment:Entity
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }

        public string Text { get; set; }

        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
    }
}
