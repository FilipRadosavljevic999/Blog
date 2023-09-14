using Application.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator(BlogContext context)
        {
            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage("Email is required.")
               .EmailAddress()
               .WithMessage("Pogresan format emaila.")
               .Must(x => !context.Users.Any(u => u.Email == x))
               .WithMessage("Email se vec koristi.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username je obavezan.")
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("Username se vec koristi.");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Ime je obavezno."); 

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Prezime je obavezno."); 
        }
    }
}
