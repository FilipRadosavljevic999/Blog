using Application.Command;
using Application.DTO;
using DataAccess;
using Domain.Model;
using FluentValidation;
using Implementation.Validators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFRegisterCommand : IRegisterCommand
    {
        public int Id => 1;

        public string Name => "Register";

        public string Description => "Register User";
        private BlogContext _blogContext;
        private RegisterValidator _validator;

        public EFRegisterCommand(BlogContext blogContext, RegisterValidator validator)
        {
            _blogContext = blogContext;
            _validator = validator;
        }

        public void Execute(RegisterDTO request)
        {
            _validator.ValidateAndThrow(request);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            User u = new User();
            u.FirstName = request.FirstName;
            u.LastName = request.LastName;
            u.Username = request.Username;
            u.Role = _blogContext.Roles.ToList().ElementAt(0);
            u.Email = request.Email;

            u.Password = passwordHash;
            _blogContext.Users.Add(u);
            _blogContext.SaveChanges();
            
        }
    }
}
