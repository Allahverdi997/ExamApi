using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System.ComponentModel.DataAnnotations;

namespace Domain.Concrete.Core.Exam
{
    public sealed class Student : BaseAuditableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Class { get; set; }

        //Relations
        public List<ExamResult> ExamResults { get; set; }
    }
}
