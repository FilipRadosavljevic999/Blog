using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.AdminDTO
{
    public class ShowUsersAdminDto:BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
     
    }
}
