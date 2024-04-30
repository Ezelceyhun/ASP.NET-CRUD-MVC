using AspNet_MVC_CRUD_Islemleri.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet_MVC_CRUD_Islemleri.Controllers
{
    public class HomeController : Controller
    {
        //HomeController s�n�f�na ait bir logger tan�mlar.
        private readonly ILogger<HomeController> _logger;

        //HomeController s�n�f�n�n bir constructor'�n� tan�mlar.
        //Bu constructor, HomeController s�n�f�n�n bir �rne�i olu�turuldu�unda �a�r�lacakt�r.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //http get iste�i geldi�inde �al���r ve View() metoduyla 'Index' isimli bir view'i d�nd�r�r. 
        //View() metodu varsay�lan olarak Index.cshtml isimli bir view dosyas�n� arar ve bu dosyay� d�nd�r�r.
        public IActionResult Index()
        {
            return View();
        }

        //http get iste�i geldi�inde �al���r ve View() metoduyla 'Privacy' isimli bir view'i d�nd�r�r. 
        //View() metodu varsay�lan olarak Privacy.cshtml isimli bir view dosyas�n� arar ve bu dosyay� d�nd�r�r.
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
