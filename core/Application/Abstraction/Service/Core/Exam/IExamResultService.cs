using Application.Models.Request.Core.Exam;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Service.Core.Exam
{
    public interface IExamResultService : IBaseService<IExamResultService, ExamResult, ExamResultRequest>
    {
    }
}
