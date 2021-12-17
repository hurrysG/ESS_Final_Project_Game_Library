using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINALPROJ.Models.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }

        public Response(T data)
        {
            Data = data;
        }

    }
}