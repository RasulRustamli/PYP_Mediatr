

using Code.Aplication.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Code.Domain.Catergories.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandValidator()
        {
            RuleFor(v => v.ProductName)
                .NotEmpty().WithMessage("Product Name is required")
                .MaximumLength(200).WithMessage("Product must not exceed 200 character");
        }

    }



}
