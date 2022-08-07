using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasks.API.Migrations
{
    public partial class NomesAlterados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_usertotask");

            migrationBuilder.DropTable(
                name: "Tb_userworkspace");

            migrationBuilder.RenameColumn(
                name: "Dh_expirationrefreshtoken",
                table: "Tb_usuario",
                newName: "Dh_expiracaorefreshtoken");

            migrationBuilder.CreateTable(
                name: "Tb_integrante",
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
                    table.PrimaryKey("PK_Tb_integrante", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_integrante_Tb_usuario_Fk_user",
                        column: x => x.Fk_user,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_integrante_Tb_workspace_Fk_workspace",
                        column: x => x.Fk_workspace,
                        principalTable: "Tb_workspace",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tb_responsavelTask",
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
                    table.PrimaryKey("PK_Tb_responsavelTask", x => x.Pk_id);
                    table.ForeignKey(
                        name: "FK_Tb_responsavelTask_Tb_task_Fk_task",
                        column: x => x.Fk_task,
                        principalTable: "Tb_task",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tb_responsavelTask_Tb_usuario_Fk_user",
                        column: x => x.Fk_user,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_integrante_Fk_user",
                table: "Tb_integrante",
                column: "Fk_user");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_integrante_Fk_workspace",
                table: "Tb_integrante",
                column: "Fk_workspace");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_responsavelTask_Fk_task",
                table: "Tb_responsavelTask",
                column: "Fk_task");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_responsavelTask_Fk_user",
                table: "Tb_responsavelTask",
                column: "Fk_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_integrante");

            migrationBuilder.DropTable(
                name: "Tb_responsavelTask");

            migrationBuilder.RenameColumn(
                name: "Dh_expiracaorefreshtoken",
                table: "Tb_usuario",
                newName: "Dh_expirationrefreshtoken");

            migrationBuilder.CreateTable(
                name: "Tb_usertotask",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Fk_task = table.Column<int>(type: "int", nullable: false),
                    Fk_user = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_usertotask_Tb_usuario_Fk_user",
                        column: x => x.Fk_user,
                        principalTable: "Tb_usuario",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_userworkspace",
                columns: table => new
                {
                    Pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dh_alteracao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Dh_inclusao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Fk_user = table.Column<int>(type: "int", nullable: false),
                    Fk_workspace = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_userworkspace_Tb_workspace_Fk_workspace",
                        column: x => x.Fk_workspace,
                        principalTable: "Tb_workspace",
                        principalColumn: "Pk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_usertotask_Fk_task",
                table: "Tb_usertotask",
                column: "Fk_task");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_usertotask_Fk_user",
                table: "Tb_usertotask",
                column: "Fk_user");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_userworkspace_Fk_user",
                table: "Tb_userworkspace",
                column: "Fk_user");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_userworkspace_Fk_workspace",
                table: "Tb_userworkspace",
                column: "Fk_workspace");
        }
    }
}
