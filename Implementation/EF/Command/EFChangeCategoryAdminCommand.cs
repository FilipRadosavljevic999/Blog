using Application.Command;
using Application.DTO.AdminDTO;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EF.Command
{
    public class EFChangeCategoryAdminCommand : IChangeCategoryAdmin
    {
        private BlogContext _blogContext;
        private CategoryValidator _validator;
        public EFChangeCategoryAdminCommand(BlogContext blogContext, CategoryValidator validationRules)
        {
            _blogContext = blogContext;
            _validator = validationRules;
        }

        public int Id => 10;

        public string Name => "Change Category";

        public string Description => throw new NotImplementedException();

        public void Execute(List<object> request)
        {
            var id=Convert.ToInt32(request[0]);
            var value=request[1] as CategoryAdminDto;
            if(value == null)
            {
                throw new NullReferenceException();
            }
            var category = _blogContext.Categories.FirstOrDefault(x=>x.Id==id);
            if(category == null)
            {
                throw new NullReferenceException();
            }
            _validator.ValidateAndThrow(value);
            category.Name = value.CategoryName;
            category.Description = value.CategoryDescription;
            _blogContext.SaveChanges();
        }
    }
}
