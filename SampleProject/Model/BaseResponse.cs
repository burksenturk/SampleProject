using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Model
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
