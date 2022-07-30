using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Etiquetatask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_etiquetatask",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_etiqueta = table.Column<int>(type: "int", nullable: false),
                    Fk_task = table.Column<int>(type: "int", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_etiquetatask", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_etiquetatask_Tb_etiqueta_Fk_etiqueta",
                        column: x => x.Fk_etiqueta,
                        principalTable: "Tb_etiqueta",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_etiquetatask_Tb_task_Fk_task",
                        column: x => x.Fk_task,
                        principalTable: "Tb_task",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_etiquetatask_Fk_etiqueta",
                table: "Tb_etiquetatask",
                column: "Fk_etiqueta");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_etiquetatask_Fk_task",
                table: "Tb_etiquetatask",
                column: "Fk_task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_etiquetatask");
        }
    }
}
