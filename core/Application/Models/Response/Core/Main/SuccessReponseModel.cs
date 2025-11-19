using Application.Models.Response.Core;

namespace Application.Models.Response.Core.Main
{
    public class SuccessReponseModel<T> : BaseResponseModel<T>
    {
        public SuccessReponseModel(T data) : base(data, null, true)
        {
            Data = data;
            Errors = null;
            Success = true;
        }

        public SuccessReponseModel(T data,BasePagingResponse pagingResponse) : base(data, null, true,pagingResponse)
        {
            Data = data;
            Errors = null;
            Success = true;
            PagingResponse = pagingResponse;
        }
    }
}
