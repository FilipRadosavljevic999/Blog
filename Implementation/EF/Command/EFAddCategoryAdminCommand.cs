using Application.Command;
using Application.DTO.AdminDTO;
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
    public class EFAddCategoryAdminCommand : IAddCategoryAdmin
    {
        private BlogContext _blogContext;
        private CategoryValidator _validator;

        public EFAddCategoryAdminCommand(BlogContext blogContext, CategoryValidator validationRules)
        {
            _blogContext = blogContext;
            _validator = validationRules;
        }

        public int Id => 9;

        public string Name => "Add category";

        public string Description => throw new NotImplementedException();

        public void Execute(CategoryAdminDto request)
        {
            _validator.ValidateAndThrow(request);
            Category newcategory = new Category();
            newcategory.Name = request.CategoryName;
            newcategory.Description = request.CategoryDescription;
            _blogContext.Categories.Add(newcategory);
            _blogContext.SaveChanges();
        }
    }
}
