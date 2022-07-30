using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class Alteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_etiqueta_Tb_userworkspace_Fk_workspace",
                table: "Tb_etiqueta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dh_expirationrefreshtoken",
                table: "Tb_usuario",
                type: "Datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AddColumn<int>(
                name: "Fk_status",
                table: "Tb_bucket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_bucket_Fk_status",
                table: "Tb_bucket",
                column: "Fk_status");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_bucket_Tb_status_Fk_status",
                table: "Tb_bucket",
                column: "Fk_status",
                principalTable: "Tb_status",
                principalColumn: "Pk_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_etiqueta_Tb_workspace_Fk_workspace",
                table: "Tb_etiqueta",
                column: "Fk_workspace",
                principalTable: "Tb_workspace",
                principalColumn: "Pk_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_bucket_Tb_status_Fk_status",
                table: "Tb_bucket");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_etiqueta_Tb_workspace_Fk_workspace",
                table: "Tb_etiqueta");

            migrationBuilder.DropIndex(
                name: "IX_Tb_bucket_Fk_status",
                table: "Tb_bucket");

            migrationBuilder.DropColumn(
                name: "Fk_status",
                table: "Tb_bucket");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dh_expirationrefreshtoken",
                table: "Tb_usuario",
                type: "Datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_etiqueta_Tb_userworkspace_Fk_workspace",
                table: "Tb_etiqueta",
                column: "Fk_workspace",
                principalTable: "Tb_userworkspace",
                principalColumn: "Pk_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
