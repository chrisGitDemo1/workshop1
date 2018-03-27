using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace workshop1.Models
{
    public class OrderQueryArg
    {
        [Display(Name ="訂單編號")]
        public int? OrderID { get; set; }
        [Display(Name = "客戶名稱")]
        public string CompanyName { get; set; }
        [Display(Name = "負責員工")]
        public int? EmployeeID { get; set; }
        [Display(Name = "出貨公司")]
        public int? ShipperID { get; set; }
        [Display(Name = "訂購日期")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "需要日期")]
        public DateTime? RequiredDate { get; set; }
        [Display(Name = "出貨日期")]
        public DateTime? ShipedDate { get; set; }
    }
}