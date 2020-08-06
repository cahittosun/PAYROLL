using PAYROLL.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAYROLL.Data
{
    public static class EmployeeData
    {
        public static List<EmployeeWorkingModel> ListEmployeeWorkingData()
        {
            List<EmployeeWorkingModel> employeeWorkingModels = new List<EmployeeWorkingModel>();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 180; i >= 0; i--)
                {
                    Random random = new Random();
                    var randomNumberForOverWork = random.Next(0, 8);
                    var randomNumberForNormalWork = random.Next(0, 2);

                    employeeWorkingModels.Add(new EmployeeWorkingModel
                    {
                        IdentityNumber = "1112223322" + j,
                        WorkingDay = DateTime.Now.AddDays(-i),
                        WorkingHour = 8 - randomNumberForNormalWork,
                        OverTimeWorkingHour = randomNumberForOverWork
                    });
                }
            }
            return employeeWorkingModels;

        }
        public static List<EmployeeModel> ListEmployeeData()
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            employeeModels.Add(new EmployeeModel
            {
                IdentityNumber = "11122233220",
                EmployeeType = Enums.EmplyeeTypes.EmployeeType1,
                Name = "Cahit",
                Surname = "Tosun",
                DailyIncome = 300,
                MonthlyIncome = 9000,
                DailyOvertimePayment=0
            });
            employeeModels.Add(new EmployeeModel
            {
                IdentityNumber = "11122233221",
                EmployeeType = Enums.EmplyeeTypes.EmployeeType2,
                Name = "Can",
                Surname = "Ozkan",
                DailyIncome = 400,
                MonthlyIncome = 12000,
                DailyOvertimePayment = 450
            });
            employeeModels.Add(new EmployeeModel
            {
                IdentityNumber = "11122233222",
                EmployeeType = Enums.EmplyeeTypes.EmployeeType3,
                Name = "Caner",
                Surname = "Olkan",
                DailyIncome = 200,
                MonthlyIncome = 6000,
                DailyOvertimePayment = 100
            });
            employeeModels.Add(new EmployeeModel
            {
                IdentityNumber = "11122233223",
                EmployeeType = Enums.EmplyeeTypes.EmployeeType4,
                Name = "Cem",
                Surname = "Baran",
                DailyIncome = 500,
                MonthlyIncome = 15000,
                DailyOvertimePayment = 300
            });
            return employeeModels;
        }

        public static EmployeeModel GetEmployeeData(string IdentityNumber)
        {
           var employeeModel=  ListEmployeeData().FirstOrDefault(c=>c.IdentityNumber== IdentityNumber);
            return employeeModel;
        }
    }
}