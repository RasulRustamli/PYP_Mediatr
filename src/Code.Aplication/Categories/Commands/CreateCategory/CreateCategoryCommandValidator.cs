using Code.Aplication.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Code.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("CategoryName is required")
                .MaximumLength(200).WithMessage("CategoryName must not exceeed 200 characters")
                .MustAsync(BeUniqName).WithMessage("The specified CategoryName already exists");
        }
        public async Task<bool> BeUniqName(string categoryName,CancellationToken cancellationToken)
        {
            return await _context.Categories.AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }
    }

}
