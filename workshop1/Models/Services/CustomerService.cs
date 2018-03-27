using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace workshop1.Models.Services
{
    public class CustomerService
    {
        /// <summary>
        /// 目前所有訂單
        /// </summary>
        private static IList<Customer> Customers = new List<Customer>()
        {
            new Customer()
            {
              CustomerID = 1,
              CompanyName = "叡揚資訊",
            },
            new Customer()
            {
                CustomerID = 2,
                CompanyName = "高雄應用科技大學",
            }
        };

        /// <summary>
        /// 取得 CompnanyName by customerID
        /// </summary>
        /// <param name="customerID">客戶編號</param>
        /// <returns></returns>
        public string GetCompanyName(int customerID)
        {
            Customer customer = Customers.SingleOrDefault(m => m.CustomerID == customerID);

            return (customer != null) ? customer.CompanyName : null;
        }

        /// <summary>
        /// 取得所有客戶資料
        /// </summary>
        /// <returns></returns>
        public IList<Customer> GetCustomers()
        {
            return Customers;
        }
    }
}