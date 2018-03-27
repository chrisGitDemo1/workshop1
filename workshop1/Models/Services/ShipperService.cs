using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace workshop1.Models.Services
{
    public class ShipperService
    {
        /// <summary>
        /// 目前所有訂單
        /// </summary>
        private static IList<Shipper> Shippers = new List<Shipper>()
        {
            new Shipper()
            {
              ShipperID = 1,
              CompanyName = "黑貓"
            },
            new Shipper()
            {
                ShipperID = 2,
                CompanyName = "新竹貨運",
            }
        };

        /// <summary>
        /// 取得所有貨運商
        /// </summary>
        /// <returns></returns>
        public IList<Shipper> GetShippers()
        {
            return Shippers;
        }
    }
}