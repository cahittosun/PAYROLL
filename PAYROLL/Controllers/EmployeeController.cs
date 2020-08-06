using PAYROLL.Attributes;
using PAYROLL.Data;
using PAYROLL.Models.BaseModels;
using PAYROLL.Models.RequestModels;
using PAYROLL.Models.ResponseModels;
using PAYROLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PAYROLL.Controllers
{
    [CustomAuthorization]
    public class EmployeeController : ApiController
    {
        [HttpPost]
        [ActionName("DoGetEmployeeIncome")]
        public ServiceResponseModel<PayrollResponseModel> DoGetEmployeeIncome(IEnumerable<PayrollRequestModel> model)
        {
            using (ServiceResponseModel<PayrollResponseModel> PayrollResponseModel = new ServiceResponseModel<PayrollResponseModel>())
            {
                using (IncomeService incomeService = new IncomeService())
                {
                    try
                    {
                        foreach (var item in model)
                        {
                            var employeeObject = EmployeeData.GetEmployeeData(item.IdentityNumber);

                            PayrollResponseModel.Result.Add(new PayrollResponseModel
                            {
                                EmployeeType = employeeObject.EmployeeType,
                                IdentityNumber = item.IdentityNumber,
                                Income = incomeService.DoCalculateIncome(item),
                                Name = employeeObject.Name,
                                Surname = employeeObject.Surname,
                                WorkingDateEnd = item.WorkingDateEnd,
                                WorkingDateStart = item.WorkingDateStart

                            });

                        }
                        if (PayrollResponseModel != null && PayrollResponseModel.Result.Any())
                        {
                            PayrollResponseModel.IsSuccessful = true;
                        }

                        return PayrollResponseModel;

                    }
                    catch (Exception ex)
                    {
                        PayrollResponseModel.IsSuccessful = false;
                        PayrollResponseModel.Message = ex.Message;
                        return PayrollResponseModel;
                    }
                }
            }
        }
    }
}
