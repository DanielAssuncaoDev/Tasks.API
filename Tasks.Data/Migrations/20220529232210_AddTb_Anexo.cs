using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Anexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_anexo",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ds_type = table.Column<string>(type: "Varchar(10)", nullable: true),
                    Qt_bytes = table.Column<int>(type: "int", nullable: false),
                    Fk_task = table.Column<int>(type: "int", nullable: false),
                    Fk_owner = table.Column<int>(type: "int", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_anexo", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_anexo_Tb_task_Fk_task",
                        column: x => x.Fk_task,
                        principalTable: "Tb_task",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_anexo_Tb_usuario_Fk_owner",
                        column: x => x.Fk_owner,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_anexo_Fk_owner",
                table: "Tb_anexo",
                column: "Fk_owner");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_anexo_Fk_task",
                table: "Tb_anexo",
                column: "Fk_task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_anexo");
        }
    }
}
