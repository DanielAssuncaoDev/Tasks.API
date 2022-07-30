using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Userworkspace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_userworkspace",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_user = table.Column<int>(type: "int", nullable: false),
                    Fk_workspace = table.Column<int>(type: "int", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_userworkspace", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_userworkspace_Tb_usuario_Fk_user",
                        column: x => x.Fk_user,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_userworkspace_Tb_workspace_Fk_workspace",
                        column: x => x.Fk_workspace,
                        principalTable: "Tb_workspace",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_userworkspace_Fk_user",
                table: "Tb_userworkspace",
                column: "Fk_user");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_userworkspace_Fk_workspace",
                table: "Tb_userworkspace",
                column: "Fk_workspace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_userworkspace");
        }
    }
}
