using Domain.Concrete.Base.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Core.Application
{
    public class Configuration:BaseEntity
    {
        public string JWTKey { get; set; }
        public string AzureConnectionString { get; set; }
        public string AzureStorageUrl { get; set; }
        public string AzureFileContainer { get; set; }
    }
}
