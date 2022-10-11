using Bussinies.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReferansController : Controller
    {
        private readonly IReferanceService referanceservice;

        public ReferansController(IReferanceService referanceservice)
        {
            this.referanceservice = referanceservice;
        }
        public IActionResult Index()
        {
            return View(referanceservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Referance referance, IFormFile file)
        {

            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);//acb.jpg
                string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinverilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);

                    }

                    referance.Referanceimages = RastgeleAd;
                    ViewBag.Message = referanceservice.Insert(referance);

                }
                else
                {
                    ViewBag.Error = "Lütfen .jpg , .jpeg , veya .png uzantılı dosya seçiniz";
                }
            }
            else
            {
                ViewBag.Error = "Lütfen Dosya Seçiniz";
            }
            return View();

        }
        [HttpGet]
        [Route("/Admin/Referans/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(referanceservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Referans/Update/{Id}")]
        public IActionResult Update(int Id, Referance referance, IFormFile file)
        {

            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    referance.Referanceimages = RastgeleAd;
                    ViewBag.Message = referanceservice.Update(referance);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Message = referanceservice.Update(referance);
            }

            return View(referanceservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Referans/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            referanceservice.Delete(x => x.Id == Id);
            return Redirect("/Admin/Hizmet");

        }
    }
}
