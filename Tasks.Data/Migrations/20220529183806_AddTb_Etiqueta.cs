using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Etiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_bucket_Tb_workspace_WorkspacePk_id",
                table: "Tb_bucket");

            migrationBuilder.DropIndex(
                name: "IX_Tb_bucket_WorkspacePk_id",
                table: "Tb_bucket");

            migrationBuilder.DropColumn(
                name: "WorkspacePk_id",
                table: "Tb_bucket");

            migrationBuilder.CreateTable(
                name: "Tb_etiqueta",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Varchar50 = table.Column<string>(name: "Varchar(50)", type: "nvarchar(max)", nullable: true),
                    Char6 = table.Column<string>(name: "Char(6)", type: "nvarchar(max)", nullable: true),
                    Fk_workspace = table.Column<int>(type: "int", nullable: true),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_etiqueta", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_etiqueta_Tb_userworkspace_Fk_workspace",
                        column: x => x.Fk_workspace,
                        principalTable: "Tb_userworkspace",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_bucket_Fk_workspace",
                table: "Tb_bucket",
                column: "Fk_workspace");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_etiqueta_Fk_workspace",
                table: "Tb_etiqueta",
                column: "Fk_workspace");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_bucket_Tb_workspace_Fk_workspace",
                table: "Tb_bucket",
                column: "Fk_workspace",
                principalTable: "Tb_workspace",
                principalColumn: "Pk_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_bucket_Tb_workspace_Fk_workspace",
                table: "Tb_bucket");

            migrationBuilder.DropTable(
                name: "Tb_etiqueta");

            migrationBuilder.DropIndex(
                name: "IX_Tb_bucket_Fk_workspace",
                table: "Tb_bucket");

            migrationBuilder.AddColumn<int>(
                name: "WorkspacePk_id",
                table: "Tb_bucket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_bucket_WorkspacePk_id",
                table: "Tb_bucket",
                column: "WorkspacePk_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_bucket_Tb_workspace_WorkspacePk_id",
                table: "Tb_bucket",
                column: "WorkspacePk_id",
                principalTable: "Tb_workspace",
                principalColumn: "Pk_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
