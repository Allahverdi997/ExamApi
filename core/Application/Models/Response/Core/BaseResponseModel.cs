using Application.Models.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.Core
{
    public class BaseResponseModel<T>
    {
        public BaseResponseModel(T data, List<Error> errors, bool success)
        {
            Data = data;
            Errors = errors;
            Success = success;
        }

        public BaseResponseModel(T data, List<Error> errors, bool success, BasePagingResponse pagingResponse)
        {
            Data = data;
            Errors = errors;
            Success = success;
            PagingResponse = pagingResponse;
        }

        public T Data { get; set; }
        public List<Error> Errors { get; set; }
        public bool Success { get; set; }

        public BasePagingResponse? PagingResponse { get; set; }
    }

    public class BasePagingResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int DataCount { get; set; }
    }
}
