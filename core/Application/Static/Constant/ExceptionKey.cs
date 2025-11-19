using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Static.Message
{
    public static class ExceptionKey
    {
        public static string Authorized => "AuthorizedException";
        public static string BadRequest => "BadRequestException";
        public static string General => "GeneralException";
        public static string ModelState => "ModelStateException";
        public static string NotFound => "NotFoundException";
        public static string Permission => "PermissionException";
        public static string Server => "ServerException";
        public static string SqlServer => "SqlServerException";
    }
}
