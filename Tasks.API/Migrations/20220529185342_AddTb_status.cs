using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_status",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_status = table.Column<string>(type: "Varchar(80)", nullable: true),
                    Fk_workspace = table.Column<int>(type: "int", nullable: true),
                    Tg_defaultsystem = table.Column<bool>(type: "bit", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_status", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_status_Tb_workspace_Fk_workspace",
                        column: x => x.Fk_workspace,
                        principalTable: "Tb_workspace",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_status_Fk_workspace",
                table: "Tb_status",
                column: "Fk_workspace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_status");
        }
    }
}
