using Application.Models.Response.Core;
using Application.ThirdPartyConfiguration.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.Core
{
    public class PagingRequest:MapTo<BasePagingResponse>
    {
        public int PageSize { get; set; } = 1000;
        public int PageNumber { get; set; } = 1;
    }
}
