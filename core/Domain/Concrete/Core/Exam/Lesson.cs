using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Core.Exam
{
    public sealed class Lesson:BaseAuditableEntity,IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        //Realtions
        public List<LessonInfo> LessonInfos { get; set; }
        public List<ExamResult> ExamResults { get; set; }
    }
}
