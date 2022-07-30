using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class AddTb_Task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_task",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ds_task = table.Column<string>(type: "Varchar(125)", nullable: true),
                    Ds_descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_bucket = table.Column<int>(type: "int", nullable: false),
                    Fk_owner = table.Column<int>(type: "int", nullable: false),
                    Fk_usuarioresponsavel = table.Column<int>(type: "int", nullable: true),
                    Fk_useralteradorstatus = table.Column<int>(type: "int", nullable: true),
                    Fk_status = table.Column<int>(type: "int", nullable: false),
                    Nr_posicao = table.Column<int>(type: "int", nullable: false),
                    Dh_prazo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tg_inativoporworkspace = table.Column<bool>(type: "bit", nullable: false),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Tg_inativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_task", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_task_Tb_bucket_Fk_bucket",
                        column: x => x.Fk_bucket,
                        principalTable: "Tb_bucket",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_task_Tb_status_Fk_status",
                        column: x => x.Fk_status,
                        principalTable: "Tb_status",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_task_Tb_usuario_Fk_owner",
                        column: x => x.Fk_owner,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_task_Tb_usuario_Fk_useralteradorstatus",
                        column: x => x.Fk_useralteradorstatus,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_task_Tb_usuario_Fk_usuarioresponsavel",
                        column: x => x.Fk_usuarioresponsavel,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_task_Fk_bucket",
                table: "Tb_task",
                column: "Fk_bucket");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_task_Fk_owner",
                table: "Tb_task",
                column: "Fk_owner");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_task_Fk_status",
                table: "Tb_task",
                column: "Fk_status");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_task_Fk_useralteradorstatus",
                table: "Tb_task",
                column: "Fk_useralteradorstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_task_Fk_usuarioresponsavel",
                table: "Tb_task",
                column: "Fk_usuarioresponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_task");
        }
    }
}
