using Bussinies.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICampaingsService campaingsservice ;
        private readonly IInteractionsService interactionsservice;
        private readonly IMinistrationService ministrationservice;
        private readonly IReferanceService referanceservice;


        public HomeController(ICampaingsService campaingsservice, IInteractionsService interactionsservice, IMinistrationService ministrationservice, IReferanceService referanceservice)
        {
            this.campaingsservice = campaingsservice;
            this.interactionsservice = interactionsservice;
            this.ministrationservice = ministrationservice;
            this.referanceservice = referanceservice;

        }

        public IActionResult Index()
        {
            return View(campaingsservice.GetAll());
        }
        [HttpGet]
        public IActionResult ArizaKaydi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ArizaKaydi(Interactions interactions)
        {
            return View(interactionsservice.Insert(interactions));
        }
        [HttpGet]
        public IActionResult ArizaDetay()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ArizaDetay (int Id)
        {
            return View(ministrationservice.GetById(x => x.Id==Id));
        }


    }
}
