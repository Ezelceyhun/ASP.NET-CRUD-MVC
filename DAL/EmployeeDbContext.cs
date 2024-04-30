using AspNet_MVC_CRUD_Islemleri.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace AspNet_MVC_CRUD_Islemleri.DAL
{
    public class EmployeeDbContext : DbContext
    {
        //Entity Framework Core ile bir veritabanı bağlantısı oluşturmak için kullanılan DbContext sınıfını tanımlar.
        public EmployeeDbContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}
