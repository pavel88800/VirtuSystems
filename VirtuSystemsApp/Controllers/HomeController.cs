using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtuSystemsApp.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Hello ASP.NET Core";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Route("A")]
        public string App()
        {
            return "{\r\n  \"success\": true,\r\n  \"users\": [\r\n    {\r\n      \"userID\": 1,\r\n      \"name\": \"Вася\",\r\n      \"surname\": \"Иванов\",\r\n      \"date\": \"10/08/1991\",\r\n      \"email\": \"vasiv@mail.ru\",\r\n      \"married\": false\r\n    },\r\n    {\r\n      \"userID\": 2,\r\n      \"name\": \"Петя\",\r\n      \"surname\": \"Федоров\",\r\n      \"date\": \"03/08/1993\",\r\n      \"email\": \"petfed@yandex.ru\",\r\n      \"married\": true\r\n    },\r\n    {\r\n      \"userID\": 3,\r\n      \"name\": \"Вова\",\r\n      \"surname\": \"Кузнецов\",\r\n      \"date\": \"11/07/1989\",\r\n      \"email\": \"vok@mail.ru\",\r\n      \"married\": false\r\n    },\r\n    {\r\n      \"userID\": 4,\r\n      \"name\": \"Саша\",\r\n      \"surname\": \"Сидоров\",\r\n      \"date\": \"05/08/1991\",\r\n      \"email\": \"vvvs@mail.ru\",\r\n      \"married\": true\r\n    }\r\n  ]\r\n}";
        }
    }
}