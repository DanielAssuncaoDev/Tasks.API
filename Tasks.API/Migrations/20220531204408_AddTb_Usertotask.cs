using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Usertotask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_task_Tb_usuario_Fk_usuarioresponsavel",
                table: "Tb_task");

            migrationBuilder.DropIndex(
                name: "IX_Tb_task_Fk_usuarioresponsavel",
                table: "Tb_task");

            migrationBuilder.DropColumn(
                name: "Fk_usuarioresponsavel",
                table: "Tb_task");

            migrationBuilder.CreateTable(
                name: "Tb_usertotask",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_user = table.Column<int>(type: "int", nullable: false),
                    Fk_task = table.Column<int>(type: "int", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_usertotask", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_usertotask_Tb_task_Fk_task",
                        column: x => x.Fk_task,
                        principalTable: "Tb_task",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_usertotask_Tb_usuario_Fk_user",
                        column: x => x.Fk_user,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_usertotask_Fk_task",
                table: "Tb_usertotask",
                column: "Fk_task");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_usertotask_Fk_user",
                table: "Tb_usertotask",
                column: "Fk_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_usertotask");

            migrationBuilder.AddColumn<int>(
                name: "Fk_usuarioresponsavel",
                table: "Tb_task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_task_Fk_usuarioresponsavel",
                table: "Tb_task",
                column: "Fk_usuarioresponsavel");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_task_Tb_usuario_Fk_usuarioresponsavel",
                table: "Tb_task",
                column: "Fk_usuarioresponsavel",
                principalTable: "Tb_usuario",
                principalColumn: "Pk_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
