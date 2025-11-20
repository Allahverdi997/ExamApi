using Application.Models.Request.Core.Exam;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Exam
{
    public class ExamResultRequestValidator : AbstractValidator<ExamResultRequest>
    {
        public ExamResultRequestValidator()
        {
            RuleFor(x => x.ExamValue)
                .NotEmpty().WithMessage("Boş ola bilməz.")
                .LessThanOrEqualTo(9).WithMessage("9'dan yuxari daxil edile bilməz.");
        }
    }
}
