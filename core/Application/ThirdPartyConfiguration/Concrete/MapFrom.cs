using Application.ThirdPartyConfiguration.Abstract;
using Domain.Abstract.Marker;
using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThirdPartyConfiguration.Concrete
{
    public abstract class MapFrom<T> : IMapFrom<T>
    {
        public virtual Dictionary<string, string>? GetAdditionalPropertyMapping()
        {
            return null;
        }

        public Type GetDestinationType() => typeof(T);
    }

    public abstract class MapTo<T> : IMapTo<T>
    {
        public virtual Dictionary<string, string>? GetAdditionalPropertyMapping()
        {
            return null;
        }

        public Type GetDestinationType() => typeof(T);
    }
}
