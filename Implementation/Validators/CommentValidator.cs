using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CommentValidator : AbstractValidator<CommentDto>
    {
        public CommentValidator()
        {
            RuleFor(x=>x.Comment).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(1,255).WithMessage("Komentar mora imati najmanje 1 a najvise 255 karaktera");
        }
    }
}
