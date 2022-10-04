using Code.Application.Common.Mappings;
using Code.Domain.Entities;

namespace Code.Application.Categories.Queries.GetCategories
{
    public class CategoryDto:IMapFrom<Category>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

    }
}
