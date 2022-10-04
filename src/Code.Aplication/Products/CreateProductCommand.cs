using Code.Aplication.Common.Interfaces;
using Code.Domain.Entities;
using Code.Domain.Entity;
using MediatR;

namespace Code.Domain.Catergories.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        public int? CategoryId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
               ProductName = request.ProductName,
               UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitInStock,
               CategoryId = request.CategoryId,
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
