using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Base.Entites
{
    public class BaseAuditableEntityWithCreator:BaseAuditableEntity
    {
        public int CreatorUserId { get; set; } = 1;
    }
}
