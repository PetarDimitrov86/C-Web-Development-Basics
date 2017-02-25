namespace PizzaMore.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using BindingModels;
    using ServiceLayers;
    using SimpleHttpServer.Models;
    using Data;
    using Security;

    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signup(UserBindingModel model, HttpResponse response)
        {
            new RegisterNewUser().RegUser(model);

            Redirect(response, "/home/index");

            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signin(UserBindingModel model, HttpSession session, HttpResponse response)
        {
            new UserSigningIn().TrySigningIn(model, session);
            if (signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/indexlogged");
                return null;
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            signInManager.Logout(session);
            Redirect(response, "/home/index");
            return null;
        }
    }
}