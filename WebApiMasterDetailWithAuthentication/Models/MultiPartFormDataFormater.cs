using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiMasterDetailWithAuthentication.Models.DTOs;

namespace WebApiMasterDetailWithAuthentication.Models
{
    public class MultiPartFormDataFormater : MediaTypeFormatter
    {
        public MultiPartFormDataFormater()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
        }
        public override bool CanReadType(Type type)
        {
            return type == typeof(OrderRequest);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }
        public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var multipartData = await content.ReadAsMultipartAsync();
            var orderData = new OrderRequest();

            foreach (var contentPart in multipartData.Contents)
            {
                var fieldName = contentPart.Headers.ContentDisposition.Name.Trim('\"');
                if (fieldName == "Order")
                {
                    var orderContent = await contentPart.ReadAsStringAsync();
                    orderData.Order = JsonConvert.DeserializeObject<Order>(orderContent);
                }
                else if (fieldName == "ImageFile")
                {
                    orderData.ImageFile = await contentPart.ReadAsByteArrayAsync();
                    orderData.ImageFileName = contentPart.Headers.ContentDisposition.FileName;
                }

            }
            return orderData;
        }
    }
}