using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace Entities.DTO
{
    public class ReponseExcel<T>
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }

        public static ReponseExcel<T> GetResult(int code, string msg, T data = default(T))
        {
            return new ReponseExcel<T>
            {
                Code = code,
                Msg = msg,
                Data = data
            };
         }
    }
}
