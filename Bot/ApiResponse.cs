using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public string ExceptionMessage { get; set; }
        public int StatusCode { get; set; }

    }
}
