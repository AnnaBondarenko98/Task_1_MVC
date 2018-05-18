using System.Security.Claims;
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
        private IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVm user)
        {

            if (ModelState.IsValid)
            {

                ClaimsIdentity claim = await UserService.Authenticate(_mapper.Map<LoginDto>(user));
                if (claim == null)

                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();

                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    return RedirectToAction("Login", new
                    {
                        area = "",
                        controller = "Account"
                    });
                }
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();

            return RedirectToAction("Login", new
            {
                area = "",
                controller = "Account"
            });
        }
    }
}