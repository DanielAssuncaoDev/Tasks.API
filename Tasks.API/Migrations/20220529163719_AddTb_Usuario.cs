using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_usuario",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_usuario = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Ds_email = table.Column<string>(type: "Varchar(200)", nullable: true),
                    Hx_password = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Hx_refreshtoken = table.Column<string>(type: "Varchar(150)", nullable: true),
                    Dh_expirationrefreshtoken = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_usuario", x => x.Pk_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_usuario");
        }
    }
}
