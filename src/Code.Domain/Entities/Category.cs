using Code.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Entities;

public class Category:BaseAuditableEntity
{
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
