using Application.DTO.AdminDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IGetUsersAdminQuery:IQuery<int, List<ShowUsersAdminDto>>
    {
    }
}
