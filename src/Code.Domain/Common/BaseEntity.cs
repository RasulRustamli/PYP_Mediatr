using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }


    }
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
