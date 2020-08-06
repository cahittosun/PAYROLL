using PAYROLL.Data;
using PAYROLL.Models.BaseModels;
using PAYROLL.Models.EmployeeModels;
using PAYROLL.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Services
{
    public class IncomeService : IDisposable
    {
        List<EmployeeModel> employeeModels;
        List<EmployeeWorkingModel> employeeWorkingModels;
        public IncomeService()
        {
            #region DUMMY DATA
            employeeModels = EmployeeData.ListEmployeeData();
            employeeWorkingModels = EmployeeData.ListEmployeeWorkingData();
            #endregion

        }
        public decimal DoCalculateIncome(PayrollBaseModel model)
        {
            try
            {
                var employeeDetail = employeeModels.FirstOrDefault(c => c.IdentityNumber == model.IdentityNumber);
                if (employeeDetail != null)
                {
                    var employeeWorkingDetails = employeeWorkingModels.Where(c => c.IdentityNumber == model.IdentityNumber
                    && c.WorkingDay <= model.WorkingDateEnd && c.WorkingDay >= model.WorkingDateStart);
                    if (employeeWorkingDetails.Any())
                    {
                        if (employeeDetail.EmployeeType == Enums.EmplyeeTypes.EmployeeType1)
                        {
                            return employeeDetail.MonthlyIncome;
                        }
                        else if (employeeDetail.EmployeeType == Enums.EmplyeeTypes.EmployeeType2)
                        {
                            return employeeDetail.DailyIncome * (decimal)(model.WorkingDateEnd - model.WorkingDateStart).TotalDays;
                        }
                        else if (employeeDetail.EmployeeType == Enums.EmplyeeTypes.EmployeeType3)
                        {
                            return employeeDetail.MonthlyIncome + employeeWorkingDetails.Sum(c => c.OverTimeWorkingHour) * employeeDetail.DailyOvertimePayment;
                        }
                        else if (employeeDetail.EmployeeType == Enums.EmplyeeTypes.EmployeeType4)
                        {
                            return employeeDetail.DailyIncome * (decimal)(model.WorkingDateEnd - model.WorkingDateStart).TotalDays + employeeWorkingDetails.Sum(c => c.OverTimeWorkingHour) * employeeDetail.DailyOvertimePayment;
                        }
                    }
                }
            }
            catch
            {

                return 0;
            }

            return 0;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}