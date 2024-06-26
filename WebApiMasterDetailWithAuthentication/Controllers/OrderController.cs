using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiMasterDetailWithAuthentication.Models;
using WebApiMasterDetailWithAuthentication.Models.DTOs;

namespace WebApiMasterDetailWithAuthentication.Controllers
{
    public class OrderController : ApiController
    {
        private AppDbContext db;
        public OrderController()
        {
            db = new AppDbContext();
        }
        //[Authorize(Roles =("Viewer"))]
        public IHttpActionResult GetOrders()
        {
            var result=db.Orders.ToList();
            result.OrderByDescending(x => x.OrderId);
            return Ok(result);
        }
        [Authorize(Roles = ("User,Admin"))]
        public IHttpActionResult GetOrderById(int id)
        {
            var result = db.Orders.
                Where(e=>e.OrderId==id).ToList();           
            return Ok(result);
        }
        [Authorize(Roles = ("User,Admin"))]
        public IHttpActionResult DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            var orderItems = db.OrderItems.Where(i => i.OrderId == id).ToList();
            foreach (var item in orderItems)
            {
                db.OrderItems.Remove(item); 
            }
            db.Orders.Remove(order);
            db.SaveChanges();
            return Ok("Order Deleted Successfully");
        }
        [Authorize(Roles = ("User,Admin"))]
        public IHttpActionResult PostOrder(OrderRequest request)
        {
            if(request == null)
            {
                return BadRequest("Order data is missing");
            }
            Order obj = request.Order;
            byte[] imageFile = request.ImageFile;
            
            if (imageFile!=null && imageFile.Length>0)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string filePath=Path.Combine("~/Images/")+fileName;
                File.WriteAllBytes(HttpContext.Current.Server.MapPath(filePath), imageFile);
                obj.ImageUrl= filePath;
            }
            Order order = new Order
            {
                OrderNo=obj.OrderNo,
                OrderDate=obj.OrderDate,
                CustomerName=obj.CustomerName,
                IsPaid=obj.IsPaid,
                ImageUrl= obj.ImageUrl,
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var orderObj=db.Orders.FirstOrDefault(x=>x.OrderNo==obj.OrderNo);
            if(orderObj != null && obj.OrderItems!=null) 
            { 
                foreach(var item in obj.OrderItems)
                {
                    OrderItem itemobj = new OrderItem
                    {
                        OrderId= orderObj.OrderId,
                        ProductId= item.ProductId,
                        Quantity= item.Quantity,
                        Price= item.Price,
                    };
                    db.OrderItems.Add(itemobj);
                }
            }
            db.SaveChanges();
            return Ok("Order saved Successfully");
        }
        [Authorize(Roles = ("User"))]
        public IHttpActionResult PutOrder(int id, OrderRequest request)
        {
            Order order = db.Orders.FirstOrDefault(x=>x.OrderId==id);
            if (id != request.Order.OrderId)
            {
                return BadRequest();
            }
            if(order == null)
            {
                return NotFound();
            }
            if(request.Order == null)
            {
                return BadRequest("Order data is missing");
            }
            Order obj = request.Order;
            byte[] imageFile = request.ImageFile;
            string filePath = "";
            if (imageFile != null && imageFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                filePath = Path.Combine("~/Images/") + fileName;
                File.WriteAllBytes(HttpContext.Current.Server.MapPath(filePath), imageFile);
                obj.ImageUrl = filePath;
            }
            order.OrderNo = obj.OrderNo;
            order.OrderDate=obj.OrderDate;
            order.CustomerName= obj.CustomerName;
            order.ImageUrl= obj.ImageUrl;
            var existingOrderItems = db.OrderItems.Where(x => x.OrderId == order.OrderId);
            if (existingOrderItems.Any())
            {
                db.OrderItems.RemoveRange(existingOrderItems);
            }
            if(obj.OrderItems!=null)
            {
                foreach (var item in obj.OrderItems)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    db.OrderItems.Add(orderItem);
                }
            }
            db.SaveChanges();
            return Ok("Updated successfully");
        }
    }
}
