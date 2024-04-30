using AspNet_MVC_CRUD_Islemleri.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet_MVC_CRUD_Islemleri.Controllers
{
    public class HomeController : Controller
    {
        //HomeController sýnýfýna ait bir logger tanýmlar.
        private readonly ILogger<HomeController> _logger;

        //HomeController sýnýfýnýn bir constructor'ýný tanýmlar.
        //Bu constructor, HomeController sýnýfýnýn bir örneði oluþturulduðunda çaðrýlacaktýr.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //http get isteði geldiðinde çalýþýr ve View() metoduyla 'Index' isimli bir view'i döndürür. 
        //View() metodu varsayýlan olarak Index.cshtml isimli bir view dosyasýný arar ve bu dosyayý döndürür.
        public IActionResult Index()
        {
            return View();
        }

        //http get isteði geldiðinde çalýþýr ve View() metoduyla 'Privacy' isimli bir view'i döndürür. 
        //View() metodu varsayýlan olarak Privacy.cshtml isimli bir view dosyasýný arar ve bu dosyayý döndürür.
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
