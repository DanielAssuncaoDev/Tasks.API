using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Itemchecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_itemchecklist",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_checklist = table.Column<int>(type: "int", nullable: false),
                    Ds_item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tg_concluido = table.Column<bool>(type: "bit", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_itemchecklist", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_itemchecklist_Tb_checklist_Fk_checklist",
                        column: x => x.Fk_checklist,
                        principalTable: "Tb_checklist",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_itemchecklist_Fk_checklist",
                table: "Tb_itemchecklist",
                column: "Fk_checklist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_itemchecklist");
        }
    }
}
