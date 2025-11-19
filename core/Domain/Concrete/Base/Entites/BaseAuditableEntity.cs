using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Base.Entites
{
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreateDate { get; set; }= new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day);

        public int? LastUpdatorUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
