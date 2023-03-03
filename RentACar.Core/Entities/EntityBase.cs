using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities
{
    public abstract class EntityBase:IEntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public virtual string CreatedBy { get; set; }
        public virtual DateTimeOffset? UpdatedDate { get; set; }
        public virtual string? UpdatedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string? IsDeletedBy { get; set; }
        public virtual DateTime? DeletedTime { get; set; }



    }
}
