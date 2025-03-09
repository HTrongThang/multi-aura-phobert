using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Network
{
    public abstract class APIResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class SuccessResponse<T> : APIResponse<T>
    {
        public T Data { get; set; }

        public SuccessResponse(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }

    public class ErrorResponse<T> : APIResponse<T>
    {
        public string Error { get; set; }

        public ErrorResponse(int status, string message, string error)
        {
            Status = status;
            Message = message;
            Error = error;
        }
    }
}
