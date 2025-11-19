using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThirdPartyConfiguration.Abstract
{
    public interface IBaseMap
    {
        Type GetDestinationType();
        public Type GetSourceType() => GetType();
        Dictionary<string, string>? GetAdditionalPropertyMapping();
    }
}
