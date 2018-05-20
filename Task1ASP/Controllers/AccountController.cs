using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Web;
using AutoMapper;
using BlogAsp.BLL.DTO;
using BlogAsp.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Task1ASP.Models.Login;

namespace Task1ASP.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVm user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var claim = await UserService.Authenticate(_mapper.Map<LoginDto>(user));

            if (claim != null)
            {
                AuthenticationManager.SignOut();

                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);

                return RedirectToAction("GetArticles", "Article");
            }

            ModelState.AddModelError("", "Неверный логин или пароль.");

            return View(user);
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();

            return RedirectToAction("GetArticles", "Article");
        }
    }
}