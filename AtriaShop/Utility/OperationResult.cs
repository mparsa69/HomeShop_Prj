using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class OperationResult
    {
        public bool IsSucceded { get; set; } = false;
        public string Message { get; set; }
        public OperationResult Succeded(string message = "عملیات با موفقیت انجام شد.")
        {
            Message = message;
            IsSucceded = true;
            return this;
        }

        public OperationResult Faild(string message = "عملیات با خطا روبرو شد..")
        {
            Message = message;
            IsSucceded = false;
            return this;
        }
    }
}
