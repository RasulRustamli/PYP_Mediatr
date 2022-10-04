using Code.Aplication.Common.Interfaces;
using FluentValidation;


namespace Code.Domain.Catergories.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ProductName)
                .NotEmpty().WithMessage("Product Name is required")
                .MaximumLength(200).WithMessage("Product must not exceed 200 character");
        }

    }

}
