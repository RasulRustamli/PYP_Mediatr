using Code.Aplication.Common.Interfaces;
using Code.Domain.Catergories.Commands.UpdateProduct;
using MediatR;

namespace Code.Domain.Catergories.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        public int? CategoryId { get; set; }
    }
}

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(new object[] {request.Id},cancellationToken);
            if (entity == null)
            {
                throw new Exception("");
            }

            entity.ProductName = request.ProductName;
            entity.UnitPrice = request.UnitPrice;
            entity.UnitsInStock = request.UnitInStock;
            entity.CategoryId = request.CategoryId;

           await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

