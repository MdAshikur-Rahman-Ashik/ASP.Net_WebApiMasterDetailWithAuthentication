using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMasterDetailWithAuthentication.Models.DTOs
{
    public class OrderRequest
    {
        public Order Order { get; set; }
        public byte[] ImageFile { get; set; }
        public string ImageFileName { get; set; }
    }
}