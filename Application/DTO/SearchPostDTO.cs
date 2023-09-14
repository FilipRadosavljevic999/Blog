using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class SearchPostDTO:BaseDTO
    {
        public int PerPage { get; set; }
        public int Page { get; set; }
        public string? KeyWord { get; set; }
        public int? CategoryId { get; set; }
    }
}
