using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Models.EmployeeModels
{
    public class EmployeeWorkingModel
    {
        public string IdentityNumber { get; set; }
        public DateTime WorkingDay { get; set; }
        public int WorkingHour { get; set; }
        public int OverTimeWorkingHour { get; set; }

    }
}