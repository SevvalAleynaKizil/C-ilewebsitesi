using Bussinies.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class KullaniciController : Controller
    {
        private readonly IUsersService usersservice;
        public KullaniciController(IUsersService usersservice)
        {
            this.usersservice = usersservice;
        }

        public IActionResult Index()
        {
            return View(usersservice.GetAll());

        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Users users)
        {
            ViewBag.Message = usersservice.Insert(users);
            return View();

        }

        [HttpGet]
        [Route("/admin/Kullanici/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(usersservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Kullanici/Update/{Id}")]
        public IActionResult Update(int Id, Users users)
        {
            ViewBag.Message = usersservice.Update(users);
            return View(usersservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/Kullanici/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = usersservice.Delete(x => x.Id == Id);
            return Redirect("/admin/Kullanici");

        }
    }
}
