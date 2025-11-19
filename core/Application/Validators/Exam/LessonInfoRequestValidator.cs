using Application.Models.Request.Core.Exam;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Exam
{
    public class LessonInfoRequestValidator : AbstractValidator<LessonInfoRequest>
    {
        public LessonInfoRequestValidator()
        {
            RuleFor(x => x.Lesson.Code)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .MaximumLength(3).WithMessage("3 simvoldan yuxari daxil edile bilməz.");

            RuleFor(x => x.Lesson.Name)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .MaximumLength(30).WithMessage("30 simvoldan yuxari daxil edile bilməz.");

            RuleFor(x => x.Class)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .LessThanOrEqualTo(99).WithMessage("100'den yuxari daxil edile bilməz."); ;

            RuleFor(x => x.Teacher.Name)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .MaximumLength(20).WithMessage("20 simvoldan yuxari daxil edile bilməz.");

            RuleFor(x => x.Teacher.Surname)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .MaximumLength(20).WithMessage("20 simvoldan yuxari daxil edile bilməz.");
        }
    }
}
