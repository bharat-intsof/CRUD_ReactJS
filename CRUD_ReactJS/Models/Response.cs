using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_ReactJS.Models
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponsMessage { get; set; }
        public B_product product { get; set; }
        public List<B_product> lstProduct { get; set; }
    }
}