using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Service.Core.Exam;
using Application.Concrete.AppConfig;
using Application.Models.Request.Core;
using Application.Models.Request.Core.Exam;
using Application.Models.Response.Core.Exam;
using Application.Models.Response.Core.Main;
using AutoMapper;
using Domain.Concrete.Core.Exam;
using FluentValidation;
using HashingService.Abstract;
using HashingService.Concrete;
using Infrastructure.Services.Core.Auth;
using JWTService.Abstract;
using JWTService.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Core.Exam
{
    public class LessonService : BaseService<LessonService, LessonInfo, LessonInfoRequest>, ILessonService
    {


        public LessonService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<LessonService> logger,
            IAppSession appSession,
            IValidator<LessonInfoRequest> validator):base(unitOfWork,mapper,logger,appSession,validator)
        {
        }

        public override async Task<LessonInfo> GetDbDataAsync(int id)
        {
            return await _unitOfWork.LessonInfoReadRepository.Get(id,true,x=>x.Lesson,x=>x.Teacher).FirstOrDefaultAsync();
        }

        public override async Task<List<LessonInfo>> GetDbDataListAsync(PagingRequest pagingRequest)
        {
            return await _unitOfWork.LessonInfoReadRepository.Table
                         .Skip((pagingRequest.PageNumber - 1) * pagingRequest.PageSize)
                         .Take(pagingRequest.PageSize)
                         .Include(x=>x.Lesson)
                         .Include(x=>x.Teacher)
                         .OrderByDescending(x => x.CreateDate)
                         .ToListAsync();
        }

        public override async Task<int> GetDbDataListCountAsync() => await _unitOfWork.LessonInfoReadRepository.CountAsync();

        protected override Task<List<TEntity>> BulkInsertDbAsync<TRequest, TEntity>(List<TRequest> request)
        {
            throw new NotImplementedException();
        }

        protected override async Task<LessonInfo> InsertDbAsync(LessonInfo mappedEntity)
        {
            await _unitOfWork.LessonInfoWriteRepository.AddAsync(mappedEntity);

            return mappedEntity;
        }

        protected override async Task<LessonInfo> UpdateDbAsync(LessonInfo entity)
        {
            await _unitOfWork.LessonInfoWriteRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
