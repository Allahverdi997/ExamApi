using Application.Attributes;
using Application.ThirdPartyConfiguration.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThirdPartyConfiguration.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly();
            CustomMappings();

        }

        private void CustomMappings()
        {
            
        }

        private void ApplyMappingsFromAssembly()
        {
            var baseType = typeof(IBaseMap);
            var exportedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
            var types = exportedTypes
            .Where(t => t.GetInterfaces().Any(x => x == baseType) && t.IsClass && t.IsAbstract == false)
            .ToList();

            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is IBaseMap instance)
                {
                    //var methodInfo = type.GetMethod("GetDestinationType") ?? type.GetInterface("IMapFrom`1")!.GetMethod("GetDestinationType");
                    //var destType = methodInfo?.Invoke(instance, Array.Empty<object>()) as Type;
                    var destType = instance.GetType(); 
                    var srcType= instance.GetDestinationType();
                    if (destType != null)
                    {
                        var map = this.CreateMap(srcType, destType);

                        //add mapping of custom props (db join)

                        var willCustomMappingProperties = type.GetProperties().Where(t => t
                                         .GetCustomAttributes(inherit: true).Any(a => a.GetType()
                                         .Equals(typeof(PropertyMapAttribute))));

                        foreach (var item in willCustomMappingProperties)
                        {
                            var propertyMapAttribute = item.GetCustomAttribute(typeof(PropertyMapAttribute)) as PropertyMapAttribute;

                            map.ForMember(item.Name, x => x.MapFrom(propertyMapAttribute?.FullName));

                        }

                        //var additionalMaps = instance.GetAdditionalPropertyMapping();
                        //if (additionalMaps != null)
                        //{
                        //    foreach (var item in additionalMaps)
                        //    {
                        //        map.ForMember(item.Key, x => x.MapFrom(item.Value));
                        //    }
                        //}
                        map.ReverseMap();
                    }
                }
            }
        }
    }
}
