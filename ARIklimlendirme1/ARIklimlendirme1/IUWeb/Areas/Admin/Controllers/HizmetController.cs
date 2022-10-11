
using Bussinies.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HizmetController : Controller
    {

        private readonly IMinistrationService ministrationservice;

        public HizmetController(IMinistrationService ministrationservice)
        {
            this.ministrationservice = ministrationservice;
        }
        public IActionResult Index()
        {
            return View(ministrationservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Ministration ministration , IFormFile file , IFormFile icon)
        {

        if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);//acb.jpg
                string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinverilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAdResim = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAdResim}");



                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);

                    }

                    ministration.Images = RastgeleAdResim;
                  

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
            if (icon != null)
            {
                string DosyaUzanti = Path.GetExtension(icon.FileName);//acb.jpg
                string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinverilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");



                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        icon.CopyTo(Stream);

                    }

                    ministration.Icon = RastgeleAd;
                   

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
            ViewBag.Message = ministrationservice.Insert(ministration);
            return View();

        }
        [HttpGet]
        [Route("/Admin/Hizmet/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(ministrationservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Hizmet/Update/{Id}")]
        public IActionResult Update(int Id, Ministration ministration, IFormFile file , IFormFile icon)
        {
           
            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAdResim = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAdResim}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    ministration.Images = RastgeleAdResim;
                    
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Message = ministrationservice.Update(ministration);
            }
            if (icon != null)
            {
                string DosyaUzanti = Path.GetExtension(icon.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        icon.CopyTo(Stream);
                    }
                    ministration.Icon = RastgeleAd;
                    
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Message = ministrationservice.Update(ministration);
            }
            ViewBag.Message = ministrationservice.Update(ministration);
            return View(ministrationservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Hizmet/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ministrationservice.Delete(x => x.Id == Id);
            return Redirect("/Admin/Hizmet");

        }
    }
}
