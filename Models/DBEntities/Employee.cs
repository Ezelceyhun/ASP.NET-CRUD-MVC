using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet_MVC_CRUD_Islemleri.Models.DBEntities
{
    public class Employee
    {
        [Key] //birincil anahtar
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tablodaki sütunun otomatik olarak dolmasını sağlar
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")] // Sql'de karakter sayısını belirtir.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfbirth { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
    }
}
