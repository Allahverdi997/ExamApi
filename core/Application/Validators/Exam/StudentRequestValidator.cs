using Application.Models.Request.Core.Exam;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Exam
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(x => x.Class)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .LessThanOrEqualTo(99).WithMessage("100'den yuxari daxil edile bilməz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .MaximumLength(30).WithMessage("30 simvoldan yuxari daxil edile bilməz.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .MaximumLength(30).WithMessage("30 simvoldan yuxari daxil edile bilməz.");
        }
    }
}
