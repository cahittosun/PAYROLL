using PAYROLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Models.EmployeeModels
{
    public class EmployeeModel
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmplyeeTypes EmployeeType { get; set; }
        public decimal DailyIncome { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal DailyOvertimePayment { get; set; }

    }
}