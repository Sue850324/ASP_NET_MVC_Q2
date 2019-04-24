using ASP_NET_MVC_Q2.Models;
using System.Collections.Generic;

namespace ASP_NET_MVC_Q2.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> product { get; set; }
        public ProductDetail productDetail { get; set; }

    }
}