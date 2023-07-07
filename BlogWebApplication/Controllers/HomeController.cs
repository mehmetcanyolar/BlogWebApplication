using BL;
using BlogWebApplication.Models;
using BlogWebApplication.Utils;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CategoryManager categoryManager = new CategoryManager();
        SliderManager sliderManager = new SliderManager();
        NewsManager newsManager= new NewsManager();
        PostManager postManager= new PostManager();
        ContactManager contactManager= new ContactManager();
      

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                Categories=categoryManager.GetAll(),
                Sliders = sliderManager.GetAll(),
                News = newsManager.GetAll(),
                Posts = postManager.GetAll()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    contact.CreateDate= DateTime.Now;
                  // var mailgittimi = Utils.MailHelper.SendMail(contact); //Mail gönderim kodu
                  var sonuc =  contactManager.Add(contact);

                    if (sonuc > 0)
                    {
                        TempData["Mesaj"] = "Mesajınız başarıyla gönderilmiştir.";
                        return RedirectToAction("Contact");
                    }

                }
                catch (Exception)
                {

                    TempData["Mesaj"] = "Hata Oluştu. Mesajını gönderilememiştir.";
                }

               
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}