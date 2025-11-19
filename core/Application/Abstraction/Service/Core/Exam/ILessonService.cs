using Application.Models.Request.Core;
using Application.Models.Request.Core.Exam;
using Application.Models.Response.Core.Exam;
using Application.Models.Response.Core.Main;
using Domain.Concrete.Core.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Service.Core.Exam
{
    public interface ILessonService:IBaseService<ILessonService,LessonInfo,LessonInfoRequest>
    {
    }
}
