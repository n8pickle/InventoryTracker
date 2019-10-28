using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class doubleSku : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SKU",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "SKU",
                table: "Product",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
