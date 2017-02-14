namespace SimpleMVC.App.Controllers
{
    using MVC.Contollers;
    using MVC.Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}