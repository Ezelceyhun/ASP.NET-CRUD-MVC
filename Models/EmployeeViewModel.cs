using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet_MVC_CRUD_Islemleri.Models
{
    // Tüm projede tekrar tekrar tanımlamamak için burada genel tanımlama yapıyoruz.
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("Date Of Birth")]
        public DateTime DateOfbirth { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

        public double Salary { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get {  return FirstName + " " + LastName; }
        }
    }
}
