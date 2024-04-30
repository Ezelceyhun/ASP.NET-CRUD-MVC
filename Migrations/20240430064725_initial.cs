using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


/*
 *  Migrations Dosyalarının Gelmesi için "Paket Yöneticisi Konsolu"nu açıp öncelikle
 *  add-migration initial komutunu yazıyoruz. Dosyalarımız geldikten sonra ise veritabanına göndermek ve güncellemek için
 *  update-database komutunu yazıyoruz. Hangi Database olduğunun ayarını da appsettings.json dosyasında yapıyoruz.
*/

namespace AspNet_MVC_CRUD_Islemleri.Migrations
{
    /// <inheritdoc />
    
    //Migration:
    // Bir veritabanıyla ilişkili olan kod değişikliklerinin takibi ve yönetimi için kullanılan bir terimdir.
    public partial class initial : Migration
    {
        /// <inheritdoc />
        
        //Bu metot veritabnında Employees adında tablo oluşturur. tablo sütun ve özellikleri aşağıda verilmiştir.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        
        //Bu metot veritabanı şemasını geri almak için kullanılır. Up metoduyla yapılan değişikliklerin geri alınmasını sağlar.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
