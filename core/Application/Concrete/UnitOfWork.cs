using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Context;
using Application.Abstraction.Core.Repository.Write;
using Application.Abstraction.Core.Repository.Write.Core;
using Application.Abstraction.Repository;
using Application.Abstraction.Repository.Read;
using Application.Abstraction.Repository.Read.Core;
using Application.Static.Message;
using Domain.Concrete.Base.Entites;
using Domain.Concrete.Core.Auth;
using HashingService.Abstract;
using JWTService.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISqlDbContext _appDbContext;
        private bool _isDisposed = false;
        private readonly Dictionary<Type, object> _repositories;
        public IJWTService JWTService { get; set; }
        private readonly IUserReadRepository _userReadRepository;
        private readonly IHashService _hashService;

        public UnitOfWork(ISqlDbContext appSqlDbContext,
            ILoggerFactory loggerFactory,
            IAppSession appSession,
            IJWTService jWTService
,
            IUserReadRepository userReadRepository,
            IHashService hashService)
        {
            _repositories = new Dictionary<Type, object>();
            _appDbContext = appSqlDbContext;
            JWTService = jWTService;
            _userReadRepository =userReadRepository;
            _hashService = hashService;
        }

        #region Core

        public IExceptionNotificationReadRepository ExceptionNotificationReadRepository 
            => GetRepository<IExceptionNotificationReadRepository>();

        public IExceptionNotificationWriteRepository ExceptionNotificationWriteRepository 
            => GetRepository<IExceptionNotificationWriteRepository>();



        public IUserReadRepository UserReadRepository
            => GetRepository<IUserReadRepository>();

        public IUserRoleReadRepository UserRoleReadRepository
            => GetRepository<IUserRoleReadRepository>();

        public IRoleReadRepository RoleReadRepository
            => GetRepository<IRoleReadRepository>();

        public IConfigurationReadRepository ConfigurationReadRepository
            => GetRepository<IConfigurationReadRepository>();

        public IUserWriteRepository UserWriteRepository
            => GetRepository<IUserWriteRepository>();

        public IUserRoleWriteRepository UserRoleWriteRepository
            => GetRepository<IUserRoleWriteRepository>();

        public IConfigurationWriteRepository ConfigurationWriteRepository
            => GetRepository<IConfigurationWriteRepository>();

        #endregion

        #region Exam

        public IExamResultReadRepository ExamResultReadRepository => GetRepository<IExamResultReadRepository>();

        public IExamResultWriteRepository ExamResultWriteRepository => GetRepository<IExamResultWriteRepository>();

        public ILessonReadRepository LessonReadRepository => GetRepository<ILessonReadRepository>();

        public ILessonWriteRepository LessonWriteRepository => GetRepository<ILessonWriteRepository>();

        public ILessonInfoReadRepository LessonInfoReadRepository => GetRepository<ILessonInfoReadRepository>();

        public ILessonInfoWriteRepository LessonInfoWriteRepository => GetRepository<ILessonInfoWriteRepository>();

        public IStudentReadRepository StudentReadRepository => GetRepository<IStudentReadRepository>();

        public IStudentWriteRepository StudentWriteRepository => GetRepository<IStudentWriteRepository>();

        public ITeacherReadRepository TeacherReadRepository => GetRepository<ITeacherReadRepository>();

        public ITeacherWriteRepository TeacherWriteRepository => GetRepository<ITeacherWriteRepository>();

        #endregion

        public async Task CommitAsync(string token = null)
        {
            var entityEntries = _appDbContext.ChangeTracker.Entries();

            foreach (var entityEntry in entityEntries)
            {
                var type = entityEntry.GetType();

                User user = null;

                if (!string.IsNullOrWhiteSpace(token))
                {
                    var userId = Convert.ToInt32(JWTService.DegenerateToken(token, "Id").Value);

                    user = await _userReadRepository.GetSingleAsync(u => u.UserId==userId);
                }

                if (entityEntry.Entity.GetType().BaseType == typeof(BaseAuditableEntityWithCreator)
                    && user != null)
                {
                    var userId = user.Id;

                    if (entityEntry.State == EntityState.Added)
                    {
                        entityEntry.Property("CreatorUserId").CurrentValue = userId;
                        entityEntry.Property("CreateDate").CurrentValue = DateTime.UtcNow;
                        entityEntry.Property("Active").CurrentValue = true;
                    }
                    else if (entityEntry.State == EntityState.Modified)
                    {
                        entityEntry.Property("lastUpdator").CurrentValue = userId;
                        entityEntry.Property("lastUpdator").IsModified = true;
                        entityEntry.Property("LastUpdateDate").CurrentValue = DateTime.UtcNow;
                        entityEntry.Property("LastUpdateDate").IsModified = true;

                        entityEntry.Property("CreatorUserId").IsModified = false;
                        entityEntry.Property("CreateDate").IsModified = false;
                        entityEntry.Property("Active").CurrentValue = false;
                    }
                }
            }

            _appDbContext.SaveChanges();
            _appDbContext.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _appDbContext.DisposeContext();
                _isDisposed = true;
            }
        }

        internal TRepository GetRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.Load("Persistance").GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new KeyNotFoundException(ExceptionKey.General);

            var repository = (TRepository)Activator.CreateInstance(type, _appDbContext);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }


    }
}
