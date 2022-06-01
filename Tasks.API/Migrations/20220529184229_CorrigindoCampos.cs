using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class CorrigindoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Varchar(50)",
                table: "Tb_etiqueta",
                newName: "Ds_etiqueta");

            migrationBuilder.RenameColumn(
                name: "Char(6)",
                table: "Tb_etiqueta",
                newName: "Ds_hex");

            migrationBuilder.RenameColumn(
                name: "Varchar(100)",
                table: "Tb_bucket",
                newName: "Ds_bucket");

            migrationBuilder.AlterColumn<string>(
                name: "Ds_etiqueta",
                table: "Tb_etiqueta",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ds_hex",
                table: "Tb_etiqueta",
                type: "Char(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ds_bucket",
                table: "Tb_bucket",
                type: "Varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ds_hex",
                table: "Tb_etiqueta",
                newName: "Char(6)");

            migrationBuilder.RenameColumn(
                name: "Ds_etiqueta",
                table: "Tb_etiqueta",
                newName: "Varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Ds_bucket",
                table: "Tb_bucket",
                newName: "Varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Char(6)",
                table: "Tb_etiqueta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Char(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(50)",
                table: "Tb_etiqueta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(100)",
                table: "Tb_bucket",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(100)",
                oldNullable: true);
        }
    }
}
