using _19115.Domain.UseCases;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace _19115.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetNotificationsUseCase _getNotificationsUseCase;

        public HomeController(IGetNotificationsUseCase getNotificationsUseCase)
        {
            _getNotificationsUseCase = getNotificationsUseCase;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Notifications = await _getNotificationsUseCase.Run();
            return View();
        }
    }
}