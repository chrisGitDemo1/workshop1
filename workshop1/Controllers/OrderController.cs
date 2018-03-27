using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using workshop1.Models;
using workshop1.Models.Services;

namespace workshop1.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// 訂單查詢頁
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Query()
        {
            EmployeeService employeeService = new EmployeeService();
            ShipperService shipperService = new ShipperService();

            // 準備 [員工] 下拉選單資料
            IList<SelectListItem> employeeList = new List<SelectListItem>();
            IList<Employee> employees = employeeService.GetEmployees();
            foreach (Employee employee in employees)
            {
                employeeList.Add(new SelectListItem()
                {
                    Text = employee.FirstName + employee.LastName,
                    Value = employee.EmployeeID.ToString()
                });
            }

            ViewBag.EmployeeList = employeeService;

            // 準備 [出貨公司] 下拉選單資料
            ViewBag.ShipperList = new SelectList(shipperService.GetShippers(), "ShipperID", "CompanyName");


            return View();
        }

        /// <summary>
        /// 訂單查詢功能
        /// </summary>
        /// <param name="arg">查詢條件</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OrderList(OrderQueryArg arg)
        {
            OrderService orderService = new OrderService();
            CustomerService customerService = new CustomerService();

            // 過濾後訂單資料
            IList<Order> orders = orderService.GetOrders(arg);

            // 所有客戶資料
            ViewBag.Customers = customerService.GetCustomers();

            return View(orders);
        }
    }
}