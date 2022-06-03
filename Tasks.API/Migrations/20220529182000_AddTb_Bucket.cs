using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Bucket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_bucket",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Varchar100 = table.Column<string>(name: "Varchar(100)", type: "nvarchar(max)", nullable: true),
                    Fk_workspace = table.Column<int>(type: "int", nullable: false),
                    WorkspacePk_id = table.Column<int>(type: "int", nullable: true),
                    Nr_position = table.Column<int>(type: "int", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_bucket", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_bucket_Tb_workspace_WorkspacePk_id",
                        column: x => x.WorkspacePk_id,
                        principalTable: "Tb_workspace",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_bucket_WorkspacePk_id",
                table: "Tb_bucket",
                column: "WorkspacePk_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_bucket");
        }
    }
}
