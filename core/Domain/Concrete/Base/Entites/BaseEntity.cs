using Domain.Abstract.Marker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Base.Entites
{
    public abstract class BaseEntity:IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Active { get; set; }
    }
}
