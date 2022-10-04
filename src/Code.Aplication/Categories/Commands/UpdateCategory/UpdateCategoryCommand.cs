using Code.Aplication.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;


        public UpdateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity=await _context.Categories.FindAsync(new object[] {request.Id},cancellationToken);
            if (entity == null)
            {
                throw new Exception(""); // TODO:NotFoudException sinifi hazirlanacak
            }
            entity.CategoryName = request.CategoryName;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
