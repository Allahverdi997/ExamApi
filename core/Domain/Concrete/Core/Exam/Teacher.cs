using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Core.Exam
{
    public sealed class Teacher : BaseAuditableEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Surname { get; set; }

        //Relations
        public List<LessonInfo> LessonInfos { get; set; }
    }
}
