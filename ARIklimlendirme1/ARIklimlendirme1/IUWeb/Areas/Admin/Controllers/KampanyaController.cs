using Bussinies.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KampanyaController : Controller
    {

        private readonly ICampaingsService campaingsservice;

        public KampanyaController(ICampaingsService campaingsservice)
        {
            this.campaingsservice = campaingsservice;
        }
        public IActionResult Index()
        {
            return View(campaingsservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Campaings campaings)
        {
            ViewBag.Message = campaingsservice.Insert(campaings);
            return View();

        }

        [HttpGet]
        [Route("/admin/Kampanya/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(campaingsservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Kampanya/Update/{Id}")]
        public IActionResult Update(int Id, Campaings campaings)
        {
            ViewBag.Message = campaingsservice.Update(campaings);
            return View(campaingsservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/Kampanya/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = campaingsservice.Delete(x => x.Id == Id);
            return Redirect("/admin/Kampanya");

        }
    }
}
