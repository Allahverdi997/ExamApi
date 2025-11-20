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
    public class ExamResultService : BaseService<ExamResultService, ExamResult, ExamResultRequest>, IExamResultService
    {
        public ExamResultService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ExamResultService> logger,
            IAppSession appSession,
            IValidator<ExamResultRequest> validator) : base(unitOfWork, mapper, logger, appSession, validator)
        {
        }

        public override async Task<ExamResult> GetDbDataAsync(int id)
        {
            return await _unitOfWork.ExamResultReadRepository.Get(id, true, x => x.Lesson, x => x.Student).FirstOrDefaultAsync();
        }

        public override async Task<List<ExamResult>> GetDbDataListAsync(PagingRequest pagingRequest)
        {
            return await _unitOfWork.ExamResultReadRepository.Table
                         .Skip((pagingRequest.PageNumber - 1) * pagingRequest.PageSize)
                         .Take(pagingRequest.PageSize)
                         .Include(x => x.Student)
                         .Include(x => x.Lesson)
                         .OrderByDescending(x => x.CreateDate)
                         .ToListAsync();
        }

        public override async Task<int> GetDbDataListCountAsync() => await _unitOfWork.ExamResultReadRepository.CountAsync();

        protected override Task<List<TEntity>> BulkInsertDbAsync<TRequest, TEntity>(List<TRequest> request)
        {
            throw new NotImplementedException();
        }

        protected override async Task<ExamResult> InsertDbAsync(ExamResult mappedEntity)
        {
            await _unitOfWork.ExamResultWriteRepository.AddAsync(mappedEntity);

            return mappedEntity;
        }

        protected override async Task<ExamResult> UpdateDbAsync(ExamResult entity)
        {
            await _unitOfWork.ExamResultWriteRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
