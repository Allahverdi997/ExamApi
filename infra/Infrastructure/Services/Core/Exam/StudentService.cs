using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core.Exam;
using Application.Models.Request.Core;
using Application.Models.Request.Core.Exam;
using AutoMapper;
using Domain.Concrete.Core.Exam;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.Core.Exam
{
    public class StudentService : BaseService<StudentService, Student, StudentRequest>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<StudentService> logger,
            IAppSession appSession,
            IValidator<StudentRequest> validator) : base(unitOfWork, mapper, logger, appSession, validator)
        {
        }

        public override async Task<Student> GetDbDataAsync(int id)
        {
            return await _unitOfWork.StudentReadRepository.Get(id, true).FirstOrDefaultAsync();
        }

        public override async Task<List<Student>> GetDbDataListAsync(PagingRequest pagingRequest)
        {
            return await _unitOfWork.StudentReadRepository.Table
                         .Skip((pagingRequest.PageNumber - 1) * pagingRequest.PageSize)
                         .Take(pagingRequest.PageSize)
                         .OrderByDescending(x=>x.CreateDate)
                         .ToListAsync();
        }

        public override async Task<int> GetDbDataListCountAsync() => await _unitOfWork.StudentReadRepository.CountAsync();

        protected override Task<List<TEntity>> BulkInsertDbAsync<TRequest, TEntity>(List<TRequest> request)
        {
            throw new NotImplementedException();
        }

        protected override async Task<Student> InsertDbAsync(Student mappedEntity)
        {
            await _unitOfWork.StudentWriteRepository.AddAsync(mappedEntity);

            return mappedEntity;
        }

        protected override async Task<Student> UpdateDbAsync(Student entity)
        {
            await _unitOfWork.StudentWriteRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
