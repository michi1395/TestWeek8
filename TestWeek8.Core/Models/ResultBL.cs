using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek8.Core.Models
{
    public class ResultBL
    {
        public ResultBL(bool success, string message) : this(success, message, null) { }
        public ResultBL(bool success, string message, Exception ex)
        {
            Success = success;
            Message = message;
            InnerException = ex;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception InnerException { get; set; }
    }
}
