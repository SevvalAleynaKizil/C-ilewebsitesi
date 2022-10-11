using Bussinies.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArizaController : Controller
    {
        private readonly IInteractionsService service;
        public ArizaController(IInteractionsService service)
        {
            this.service = service;
        }
        [Route("/Admin/Ariza")]
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/Admin/Ariza");
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View(service.GetAll());
        }
        [HttpPost]
        [Route("/Ariza/Details/{Id}")]
        public IActionResult Details(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }

    }
}
