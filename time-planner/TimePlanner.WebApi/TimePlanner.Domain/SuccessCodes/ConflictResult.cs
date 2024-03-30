using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlanner.Domain.SuccessCodes
{
    public class ConflictResult<T> : IResult
    {
        public string message;

        public ConflictResult(string message)
        {
            this.message = message;
        }

        public string Message => this.message;

    }
}
