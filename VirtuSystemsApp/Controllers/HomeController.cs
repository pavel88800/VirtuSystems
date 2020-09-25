using System.Threading.Tasks;
using System.Web.Mvc;
using VirtuSystemsApp.BL;

namespace VirtuSystemsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService = new UserService();

        /// <summary>
        ///     Инициализируем страницу.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            await _userService.AddDataInDbAsync();
            return View();
        }

        /// <summary>
        ///     Получить пользователей (без пагинации)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public async Task<string> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        /// <summary>
        ///     Редактирование пользователей
        /// </summary>
        /// <param name="json">Json</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public async Task<bool> AddOrEdit(string json)
        {
            return await _userService.EditUsersAsync(json);
        }
    }
}