
using Bussinies.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class GirisController : Controller
    {
        private readonly IUsersService service;
        public GirisController(IUsersService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Username, string Password)
        {
            var BulunanUser = service.GetById(x => x.Username == Username && x.Password == Password);

            if (BulunanUser != null)
            {
                var Claims = new List<Claim>
                    {

                     new Claim("Id", BulunanUser.Id.ToString())
                    };
                var UserIdentity = new ClaimsIdentity(Claims, "YoneticiClaims");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);

                HttpContext.SignInAsync(principal);
                return Redirect("/Admin/Ariza");
            }
            else
            {

                ViewBag.Error = "Kullanıcı Adı veya Şifreniz Hatalı";
                return View();
            }


        }
    }
}
