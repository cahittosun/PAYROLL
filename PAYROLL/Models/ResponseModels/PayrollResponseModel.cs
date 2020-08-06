using PAYROLL.Enums;
using PAYROLL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Models.ResponseModels
{
    public class PayrollResponseModel:PayrollBaseModel,IDisposable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmplyeeTypes EmployeeType { get; set; }
        public decimal Income { get; set; }
    }
}