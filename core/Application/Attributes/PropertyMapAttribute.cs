using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class PropertyMapAttribute : Attribute
    {
        public string FullName { get; set; }

        public PropertyMapAttribute(string fullName)
        {
            FullName = fullName;
        }
    }
}
