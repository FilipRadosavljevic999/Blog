using Application.DTO.AdminDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryAdminDto>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).Cascade(CascadeMode.Stop).NotEmpty().Length(1,50)
                .WithMessage("Ime kategorije je obavezno i mora sadrzati najmanje 1 najvise 50 karaktera");
            RuleFor(x => x.CategoryDescription).Cascade(CascadeMode.Stop).NotEmpty().Length(3, 255)
               .WithMessage("Opis kategorije je obavezno i mora sadrzati najmanje 3 najvise 255 karaktera");
        }
    }
}
