using ASP_NET_MVC_Q2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using ASP_NET_MVC_Q2.ViewModels;
using System.Net;

namespace ASP_NET_MVC_Q2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            string filePath = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(filePath);
            List<All> list = JsonConvert.DeserializeObject<List<All>>(json);

            var result = list.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            return View(result);
        }

        public ActionResult Detail(All all)
        {

            if (String.IsNullOrEmpty(all.Price))
            {
                all.Price = "-";
            }
            else
            {
                bool resultPrice = decimal.TryParse(all.Price, out decimal typeTest);
                if (resultPrice == true)
                {
                    switch (all.Locale)
                    {
                        case "US":
                            all.Price = string.Format(new CultureInfo("en-US"), "{0:C}", typeTest);
                            break;
                        case "CA":
                            all.Price = string.Format(new CultureInfo("en-CA"), "{0:C}", typeTest);
                            break;
                        case "DE":
                            all.Price = string.Format(new CultureInfo("de-DE"), "{0:C}", typeTest);
                            break;
                        case "ES":
                            all.Price = string.Format(new CultureInfo("es-ES"), "{0:C}", typeTest);
                            break;
                        case "FR":
                            all.Price = string.Format(new CultureInfo("fr-FR"), "{0:C}", typeTest);
                            break;
                        case "JP":
                            all.Price = string.Format(new CultureInfo("ja-JP"), "{0:C}", typeTest);
                            break;
                    }
                }
            }
            if (String.IsNullOrEmpty(all.Promote_Price))
            {
                all.Promote_Price = "-";
            }
            bool resultPromote = decimal.TryParse(all.Promote_Price, out decimal typeChange);
            if (resultPromote == true)
            {
                switch (all.Locale)
                {
                    case "US":
                        all.Promote_Price = string.Format(new CultureInfo("en-US"), "{0:C}", typeChange);
                        break;
                    case "CA":
                        all.Promote_Price = string.Format(new CultureInfo("en-CA"), "{0:C}", typeChange);
                        break;
                    case "DE":
                        all.Promote_Price = string.Format(new CultureInfo("de-DE"), "{0:C}", typeChange);
                        break;
                    case "ES":
                        all.Promote_Price = string.Format(new CultureInfo("es-ES"), "{0:C}", typeChange);
                        break;
                    case "FR":
                        all.Promote_Price = string.Format(new CultureInfo("fr-FR"), "{0:C}", typeChange);
                        break;
                    case "JP":
                        all.Promote_Price = string.Format(new CultureInfo("ja-JP"), "{0:C}", typeChange);
                        break;
                }
            }
            else
            {
                all.Promote_Price = "-";
            }

            return View(all);
        }
    }
}