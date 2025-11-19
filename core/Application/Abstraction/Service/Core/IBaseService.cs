using Application.Abstraction.Models;
using Application.Models.Request.Core;
using Application.Models.Response.Core;
using Application.Models.Response.Core.Main;
using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Service.Core
{
    public interface IBaseService<T, TEntity,TRequest> where T : class where TEntity : BaseEntity where TRequest : IRequest
    {
        Task<SuccessReponseModel<TResponse>> GetDataAsync<TResponse>(int? id, TEntity? entity = null);

        Task<SuccessReponseModel<List<TResponse>>> GetDataListAsync<TResponse>(List<TEntity> entityList = null, PagingRequest pagingRequest=null);

        Task<BaseResponseModel<TResponse>> SaveDataAsync<TResponse>(TRequest request) where TResponse : class;
        Task<int> GetDbDataListCountAsync();
    }
}
