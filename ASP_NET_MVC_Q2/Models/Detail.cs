using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_NET_MVC_Q2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Product_Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Create_Date { get; set; }
        public string Locale { get; set; }
    }
}