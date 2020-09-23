using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VirtuSystemsApp.BL;

namespace VirtuSystemsApp.Controllers
{
    
    public class HomeController : Controller
    {
        private UserService _userService = new UserService();

        public async Task<ActionResult> Index()
        {
            //await _userService.AddDataInDBAsync();

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
        public async Task<string> App()
        {

            var res = await _userService.GetUsersAsync();
            return res;
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<bool> Edit(string json)
        {
            var res = await _userService.EditUsersAsync(json);

            return default;
        }

    }
}