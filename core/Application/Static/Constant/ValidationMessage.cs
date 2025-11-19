using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Static.Message
{
    public static class ValidationMessage
    {
        public static string NotEmpty(string CellName) 
        {
            return $"{CellName} xanası boş ola bilməz!";
        }

        public static string MailValidate(string CellName)
        {
            return $"{CellName} xanasına daxil edilən mail düzgün deyil!";
        }

        public static string SelectValidate(string CellName)
        {
            return $"{CellName} xanasında məlumat seçin!";
        }
    }
}
