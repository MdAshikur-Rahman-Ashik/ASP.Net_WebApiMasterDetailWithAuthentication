using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMasterDetailWithAuthentication.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}