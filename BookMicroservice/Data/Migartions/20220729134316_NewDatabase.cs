using Microsoft.EntityFrameworkCore.Migrations;

namespace BookManagement.Infrastructure.Data.Migartions
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Book_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Book_price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Book_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Book_price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_items");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
