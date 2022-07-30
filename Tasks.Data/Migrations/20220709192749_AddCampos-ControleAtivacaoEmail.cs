using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddCamposControleAtivacaoEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cd_ativacaoEmail",
                table: "Tb_usuario",
                type: "Numeric(6,0)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tg_emailAtivo",
                table: "Tb_usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cd_ativacaoEmail",
                table: "Tb_usuario");

            migrationBuilder.DropColumn(
                name: "Tg_emailAtivo",
                table: "Tb_usuario");
        }
    }
}
