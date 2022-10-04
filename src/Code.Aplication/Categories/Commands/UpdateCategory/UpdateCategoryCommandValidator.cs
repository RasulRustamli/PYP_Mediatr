using Code.Aplication.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v=>v.CategoryName)
                .NotEmpty().WithMessage("CategoryName is required")
                .MaximumLength(200).WithMessage("CategoryName must not exceeed 200 characters")
                .MustAsync(BeUniqName).WithMessage("The specified CategoryName already exists");
        }
        public async Task<bool> BeUniqName(UpdateCategoryCommand model,string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Where(c => c.Id != model.Id)
                .AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }

    }
}
