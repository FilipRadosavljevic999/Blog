using Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class ChangePostValidator : AbstractValidator<ChangePostDTO>
    {
        public ChangePostValidator()
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().Length(3, 50).WithMessage("Naslov je obavezan podatak i mora imati najmanje 3 najvise 50 karatera.");
            RuleFor(x => x.TextContent)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().MinimumLength(10).WithMessage("Content je obavezan podatak i mora imati najanje 10 karaktera.");
        }
    }
}
