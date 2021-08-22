using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public Response()
        {
        }

        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public Response(T data, string meessage = "", string[] errors = null)
        {
            Succeeded = true;
            Message = meessage;
            Errors = errors;
            Data = data;
        }
    }
}
