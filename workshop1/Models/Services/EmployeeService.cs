using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace workshop1.Models.Services
{
    public class EmployeeService
    {
        /// <summary>
        /// 目前所有訂單
        /// </summary>
        private static IList<Employee> Employees = new List<Employee>()
        {
            new Employee()
            {
                EmployeeID = 1,
                LastName = "敬騰",
                FirstName = "蕭"
            },
            new Employee()
            {
                EmployeeID = 2,
                LastName = "杰倫",
                FirstName = "周"
            },
            new Employee()
            {
                EmployeeID = 3,
                LastName = "小明",
                FirstName = "王"
            }
        };

        /// <summary>
        /// 取得所有員工
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployees()
        {
            return Employees;
        }
    }
}