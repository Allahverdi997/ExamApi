using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System.ComponentModel.DataAnnotations;

namespace Domain.Concrete.Core.Exam
{
    public sealed class ExamResult : BaseAuditableEntity, IAggregateRoot
    {
        [Key]
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public decimal ExamValue { get; set; }

        //Relations
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
