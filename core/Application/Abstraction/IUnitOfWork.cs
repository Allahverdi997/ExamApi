using Application.Abstraction.Core.Repository.Write;
using Application.Abstraction.Core.Repository.Write.Core;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Repository.Read.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IUnitOfWork:IDisposable
    {
        #region Core

        IExceptionNotificationReadRepository ExceptionNotificationReadRepository { get; }
        IExceptionNotificationWriteRepository ExceptionNotificationWriteRepository { get; }

        IUserReadRepository UserReadRepository { get; }

        IUserRoleReadRepository UserRoleReadRepository { get; }

        IConfigurationReadRepository ConfigurationReadRepository { get; }

        IUserWriteRepository UserWriteRepository { get; }

        IUserRoleWriteRepository UserRoleWriteRepository { get; }

        IConfigurationWriteRepository ConfigurationWriteRepository { get; }
        IRoleReadRepository RoleReadRepository { get; }


        Task CommitAsync(string token = null);

        #endregion

        #region Exam

        IExamResultReadRepository ExamResultReadRepository { get; }

        IExamResultWriteRepository ExamResultWriteRepository { get; }

        ILessonReadRepository LessonReadRepository { get; }

        ILessonWriteRepository LessonWriteRepository { get; }

        ILessonInfoReadRepository LessonInfoReadRepository { get; }

        ILessonInfoWriteRepository LessonInfoWriteRepository { get; }

        IStudentReadRepository StudentReadRepository { get; }

        IStudentWriteRepository StudentWriteRepository { get; }

        ITeacherReadRepository TeacherReadRepository { get; }

        ITeacherWriteRepository TeacherWriteRepository { get; }

        #endregion
    }
}
