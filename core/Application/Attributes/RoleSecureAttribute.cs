using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class RoleSecureAttribute: Attribute
    {
        public string Name { get; set; }

        public RoleSecureAttribute(string name)
        {
            Name = name;
        }
    }
}
