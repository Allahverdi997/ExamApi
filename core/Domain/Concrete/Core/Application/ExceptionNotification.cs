using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Core.Application
{
    public class ExceptionNotification:BaseEntity
    {
        public string Key { get; set; }
        public string Description { get; set; }
    }
}
