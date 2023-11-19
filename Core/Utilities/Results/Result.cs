using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this class'ın kendisidir. yani this(result) constructor'ına (2 parametreli olan) success'i(tek parametreli olan) yolla
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }       

        //Overload
        public Result(bool success)
        {
            Success = success;
            //Message = message;
        }

        //Yalnızca getter olduğu için implement sonrası böyle gelir.
        //public bool Success => throw new NotImplementedException();

        //public string Message => throw new NotImplementedException();

        public bool Success { get; }
        public string Message { get; }

    }
}
