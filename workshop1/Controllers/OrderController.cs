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
            // 準備 [員工] 下拉選單資料
            ViewBag.EmployeeList = GetEmployeeList();

            // 準備 [出貨公司] 下拉選單資料
            ViewBag.ShipperList = GetShipperList();

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

        /// <summary>
        /// 建立訂單頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateOrder()
        {
            // 準備下拉選單
            PrepareDDLSource();

            return View();
        }

        /// <summary>
        /// 建立訂單功能
        /// </summary>
        /// <param name="order">訂單資料</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

                OrderService orderService = new OrderService();
                orderService.InsOrder(order);

                return RedirectToAction("Query", "Order");
            }
            else
            {
                // 準備 [客戶名稱] 下拉選單
                ViewBag.CustomerList = GetCustomerList();

                // 準備 [負責員工] 下拉選單資料
                ViewBag.EmployeeList = GetEmployeeList();

                // 準備 [出貨公司名稱] 下拉選單資料
                ViewBag.ShipperList = GetShipperList();

                return View(order);
            }
        }

        /// <summary>
        /// 修改訂單頁面
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateOrder(int orderID)
        {
            OrderService orderService = new OrderService();

            Order order = orderService.GetOrder(orderID);

            // 準備下拉選單
            PrepareDDLSource();

            return View(order);
        }

        /// <summary>
        /// 修改訂單功能
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

                OrderService orderService = new OrderService();
                orderService.UpdOrder(order);

                return RedirectToAction("Query", "Order");
            }
            else
            {
                // 準備下拉選單
                PrepareDDLSource();

                return View(order);
            }
        }

        /// <summary>
        /// 刪除訂單功能
        /// </summary>
        /// <param name="orderID">訂單編號</param>
        /// <returns></returns>
        public ActionResult DeleteOrder(int orderID)
        {
            OrderService orderService = new OrderService();
            orderService.DelOrder(orderID);

            return RedirectToAction("Query", "Order");
        }

        /// <summary>
        /// 準備 [客戶]、[員工]、[出貨公司] 下拉選單資料於 ViewBag
        /// </summary>
        private void PrepareDDLSource()
        {
            // 準備 [客戶名稱] 下拉選單
            ViewBag.CustomerList = GetCustomerList();

            // 準備 [負責員工] 下拉選單資料
            ViewBag.EmployeeList = GetEmployeeList();

            // 準備 [出貨公司名稱] 下拉選單資料
            ViewBag.ShipperList = GetShipperList();
        }

        /// <summary>
        /// 取得[客戶]下拉選單
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetCustomerList()
        {
            CustomerService customerService = new CustomerService();
            SelectList customerList = new SelectList(customerService.GetCustomers(), "CustomerID", "CompanyName");
            return customerList;
        }

        /// <summary>
        /// 取得[員工]下拉選單資料
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetEmployeeList()
        {
            EmployeeService employeeService = new EmployeeService();
            IList<Employee> employees = employeeService.GetEmployees();
            IList<SelectListItem> employeeList = employees.Select(m => new SelectListItem
            {
                Text = m.FirstName + m.LastName,
                Value = m.EmployeeID.ToString()
            }).ToList();

            return employeeList;
        }

        /// <summary>
        /// 取得[出貨公司]下拉選單
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetShipperList()
        {
            ShipperService shipperService = new ShipperService();
            SelectList shipperList = new SelectList(shipperService.GetShippers(), "ShipperID", "CompanyName");
            return shipperList;
        }
    }
}