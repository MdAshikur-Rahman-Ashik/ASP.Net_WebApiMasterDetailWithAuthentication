using System.Net.Http.Headers;

namespace WebApiMasterDetailWithAuthentication.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public virtual Product Products { get; set; }
    }
}