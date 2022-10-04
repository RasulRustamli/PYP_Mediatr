using Code.Aplication.Common.Interfaces;
using Code.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int Id):IRequest;
    
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
      

       public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var dbCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(dbCategory == null)
            {
                throw new Exception("");//TODO:BU alan NotfoundException olucak
            }
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
