using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {   
        // readonlyler, constructorda set edilebilir.
        // iki tane constructor var , eğer iki parametreli ctor çalışırsa, this(success) kodu ile diğer tek parametreli ctor da çalışır.
        public Result(bool success,string message): this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
