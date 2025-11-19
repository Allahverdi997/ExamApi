using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System.ComponentModel.DataAnnotations;

namespace Domain.Concrete.Core.Exam
{
    public sealed class LessonInfo : BaseAuditableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int Class { get; set; }
        public int TeacherId { get; set; }

        //Relations
        public Lesson Lesson { get; set; }
        public Teacher Teacher { get; set; }
    }
}
