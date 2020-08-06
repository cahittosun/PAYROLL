using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Models.BaseModels
{
    public class ServiceResponseModel<T>:IDisposable
    {
        public HttpValidationStatus Status { get; set; }
        public long ExecutionTimeInTicks { get; set; }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public List<T> Result { get; set; }

        public ServiceResponseModel()
        {
            Result = new List<T>();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}