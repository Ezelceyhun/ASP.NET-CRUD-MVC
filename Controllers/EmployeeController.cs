using AspNet_MVC_CRUD_Islemleri.DAL;
using AspNet_MVC_CRUD_Islemleri.Models;
using AspNet_MVC_CRUD_Islemleri.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;

namespace AspNet_MVC_CRUD_Islemleri.Controllers
{
    public class EmployeeController : Controller
    {
        //EmployeeDbContext : Veritabanı bağlantısını temsil eder.
        //_context : Değişkendir. Controller sınıfından veritabanı işlemlerini gerçekleştirmek için kullanılabilir hale getirir.
        public readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            this._context = context;
        }
        [HttpGet] //Şifrelemez
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList(); // Tüm kişileri alır ve listeye çeker.
            List< EmployeeViewModel> Employeelist = new List<EmployeeViewModel>(); // Liste Oluşturur.

            if (employees != null) // Veritabanından gelen veri boş-null değilse
            {               
                foreach(var employee in employees) // Veritabanından çekilen her kişi için 'EmployeeViewModel' nesnesi oluşturur.
                                                  // Bu nesneler employeelist listesine eklenir.
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfbirth = employee.DateOfbirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    Employeelist.Add(EmployeeViewModel);
                }
                return View(Employeelist); // Index view'ini dönüdürür.
            }
            return View(Employeelist);  // Index view'ini dönüdürür.
        }
        [HttpGet] //Şifrelemez
        public IActionResult Create() 
        {

            return View(); //Create.cshtml isimli view dosyasını döndürür.
        }
        public IActionResult Create(EmployeeViewModel employeeData) // Kullanıcı tarafından gönderilen yeni kişi verilerini içerir.
        {
            try
            {
                if (ModelState.IsValid) // Gelen verinin doğruluğunu kontrol eder.
                //Koşul doğru ise yeni bir Employee nesnesi oluşturur, veritabanına eklenir ve değişiklikler kaydedilir.
                //Başarılı işlem sonrası Index sayfasına yönlendirilir.
                {
                    var employee = new Employee()
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DateOfbirth = employeeData.DateOfbirth,
                        Email = employeeData.Email,
                        Salary = employeeData.Salary
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Oluşturma Başarılı!";
                    return RedirectToAction("Index");
                }
                //İşlem Başarısız ise hata mesajı verir.
                else
                {
                    TempData["errorMessage"] = "Tüm Bilgileri Doldurun!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            } 
        }
        [HttpGet] //Şifrelemez
        public IActionResult Edit(int Id) //Düzenlenecek kişinin id'sini alır. Edit Sayfasına gönderir.
        {
            try
            {
                //Belirtilen id'ye sahip kişi veritanından alınır.
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id); 
                if (employee != null)
                {
                    //Eğer veritabanında böyle biri varsa EmployeeViewModel tipinde nesne oluşturulur.
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfbirth = employee.DateOfbirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    return View(employeeView);
                }
                else
                {
                    //Belirtilen id'ye sahip biri yoksa Index sayfasına yönlendirilir ve hata mesajı gösterilir.
                    TempData["errorMessage"] = $"Kişi Ayrıntıları Bulunamadı! ID: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }          
        }

        [HttpPost] //Şifreler
        public IActionResult Edit(EmployeeViewModel model) //Kullanıcı tarafından düzenlenmiş kişi bilgilerini içerir.
        {
            try
            {
                if (ModelState.IsValid) //Doğruluğunu kontrol eder. Doğru ise Employee nesnesi oluşturulur ve nesne veritabanında güncellenir.
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfbirth = model.DateOfbirth,
                        Email = model.Email,
                        Salary = model.Salary
                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Başarıyla Güncellendi!";
                    return RedirectToAction("Index");
                    //Başarılı işlemden sonra Index'e yönlendirilir.
                }
                else
                {
                    TempData["errorMessage"] = "Hata!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet] //Şifrelemez
        public IActionResult Delete(int Id) //Silinecek Id'yi alır. Delete sayfasına yönlendirir.
        {
            try
            {
                //Belirtilen Id'ye sahip kişiyi veritabanından alır.
                var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);
                if (employee != null) //Eğer koşul doğru ise EmployeeViewModel tipinde nesne oluşturulur ve view'e gönderilir.
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateOfbirth = employee.DateOfbirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    return View(employeeView);
                }
                else
                {
                    //Belirtilen Id'ye sahip kişi yok ise Index'e yönlendirilir ve hata mesajı gösterilir.
                    TempData["errorMessage"] = $"Kişi Ayrıntıları Bulunamadı! Aranan ID: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost] //Şifreler
        public IActionResult Delete(EmployeeViewModel model) //Silinecek kişinin bilgilerini içerir.
        {
            try
            {
                //Belirtilen Id'ye sahip kişi veritabanından alınır.
                var employee = _context.Employees.SingleOrDefault(x => x.Id == model.Id);
                if (employee != null) // Koşul doğru ise kişi veritabanından silinir ve değişiklikler kaydedilir.
                                     // Silme işleminden sonra Index'e yönlendirilir ve başarılı mesajı gösterilir.
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Kişi Silindi!";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Koşul yanlış ise Index'e yönlendirir ve sayfa da hata mesajı gösterilir.
                    TempData["errorMessage"] = $"Kişi Ayrıntıları Bulunamadı! Aranan ID: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
           
        }
    }
}
