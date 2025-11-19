using Application.Abstraction;
using Application.Abstraction.AppConfig;
using Application.Abstraction.Models;
using Application.Abstraction.Repository;
using Application.Abstraction.Service.Core;
using Application.Exceptions.Main;
using Application.Models.Data;
using Application.Models.Data.Core;
using Application.Models.Request;
using Application.Models.Request.Core;
using Application.Models.Response.Core;
using Application.Models.Response.Core.Main;
using Application.ThirdPartyConfiguration.Abstract;
using AutoMapper;
using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Core
{
    public abstract class BaseService<T,TEntity,TRequest>:IBaseService<T, TEntity,TRequest> 
        where T : class where TEntity : BaseEntity where TRequest:IRequest
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IAppSession _appSession;
        protected readonly ILogger<T> _logger;

        private readonly IValidator<TRequest> _validator;

        public BaseService(IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ILogger<T> logger, 
            IAppSession appSession, 
            IValidator<TRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _appSession = appSession;
            _validator = validator;
        }

        #region Read

        public async Task<SuccessReponseModel<TResponse>> GetDataAsync<TResponse>(int? id,TEntity? entity=null)
        {
            _logger.LogInformation($"Get db data process started for {typeof(TEntity).Name}");

            if(entity == null)
               entity =await GetDbDataAsync(id.Value);

            _logger.LogInformation($"Check data process started for {typeof(TEntity).Name}");

            if (entity == null)
                throw new NotFoundException("Data not found");

            _logger.LogInformation($"Mapping data process started for {typeof(TEntity).Name}");

            var model = _mapper.Map<TResponse>(entity);

            return new SuccessReponseModel<TResponse>(model);
        }

        public async Task<SuccessReponseModel<List<TResponse>>> GetDataListAsync<TResponse>(List<TEntity> entityList = null, PagingRequest pagingRequest=null)
        {
            _logger.LogInformation($"Get db data process started for {typeof(TEntity).Name}");

            

            if(entityList==null)
               entityList =await GetDbDataListAsync(pagingRequest);

            int dataCount = await GetDbDataListCountAsync();

            _logger.LogInformation($"Check data process started for {typeof(TEntity).Name}");

            if (!entityList.Any())
                throw new NotFoundException("Data not found");

            _logger.LogInformation($"Mapping data process started for {typeof(TEntity).Name}");

            var model = _mapper.Map<List<TResponse>>(entityList);

            BasePagingResponse pagingResponse=pagingRequest is null ? null : _mapper.Map<BasePagingResponse>(pagingRequest);

            if(pagingResponse != null)
               pagingResponse.DataCount = dataCount;

            return new SuccessReponseModel<List<TResponse>>(model,pagingResponse);
        }

        public abstract Task<TEntity> GetDbDataAsync(int id);

        public abstract Task<List<TEntity>> GetDbDataListAsync(PagingRequest pagingRequest=null);

        public abstract Task<int> GetDbDataListCountAsync();

        #endregion

        #region Write

        public async Task<BaseResponseModel<TResponse>> SaveDataAsync<TResponse>(TRequest request)
            where TResponse : class
        {
            TEntity entity;

            string token = null;

            _logger.LogInformation($"Check request process started for {typeof(TRequest).Name}");

            if (request == null) 
                throw new ArgumentNullException("Null request");

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                // Error-ları toplayıb geriyə qaytar
                var errors = validationResult.Errors
                    .Select(e=>new Error(new Content(e.PropertyName, e.ErrorMessage), e.ErrorMessage))
                    .ToList();

                return new ErrorReponseModel<TResponse>(errors);
            }

            var mappedEntity=_mapper.Map<TEntity>(request);

            if (request.Id!=0)
                entity = await UpdateDbAsync(mappedEntity);
            else
                entity = await InsertDbAsync(mappedEntity);

            await _unitOfWork.CommitAsync(_appSession.Token);

            return await GetDataAsync<TResponse>(0,entity);
        }

        protected abstract Task<TEntity> InsertDbAsync(TEntity mappedEntity);

        protected async Task<SuccessReponseModel<List<TResponse>>> BulkInsertAsync<TResponse, TRequest>(List<TRequest> request)
            where TResponse : class
        {
            _logger.LogInformation($"Check request process started for {typeof(TRequest).Name}");

            if (!request.Any())
                throw new ArgumentNullException("Null request");


            var entityList=await BulkInsertDbAsync<TRequest,TEntity>(request);

            await _unitOfWork.CommitAsync(_appSession.Token);

            return await GetDataListAsync<TResponse>(entityList);
        }

        protected abstract Task<List<TEntity>> BulkInsertDbAsync<TRequest,TEntity>(List<TRequest> request);

        protected abstract Task<TEntity> UpdateDbAsync(TEntity entity);

        #endregion

    }
}
