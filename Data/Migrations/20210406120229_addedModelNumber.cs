using Microsoft.EntityFrameworkCore.Migrations;

namespace EgdeBookingSystemV2.Data.Migrations
{
    public partial class addedModelNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Equipments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "ModelNumber",
                table: "Equipments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelNumber",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Equipments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
