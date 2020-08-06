using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Models.BaseModels
{
    public class PayrollBaseModel: IDisposable
    {
        public DateTime WorkingDateStart { get; set; }
        public DateTime WorkingDateEnd { get; set; }
        public string IdentityNumber { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}