using Microsoft.EntityFrameworkCore.Migrations;

namespace net_car_ASPNETCORE.Migrations
{
    public partial class statusveiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Veiculo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Veiculo");
        }
    }
}
