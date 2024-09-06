using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class ResponseObject
    {
        public string Message { get; set; }
        public bool status = true;
        public int statusCode = 1;
        public string last_id = "";
        public string statusMessage = "success";
        public object Data { get; set; }

        public ResponseObject result(string message, object data)
        {
            return new ResponseObject
            {
                Message = message,
                status = status,
                statusCode = statusCode,
                last_id = last_id,
                statusMessage = statusMessage,
                Data = data
            };
        }
    }
}
