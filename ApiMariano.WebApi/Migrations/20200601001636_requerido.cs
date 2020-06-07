using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiMariano.WebApi.Migrations
{
    public partial class requerido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docente_Alumnos_AlumnoId",
                table: "Docente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Docente",
                table: "Docente");

            migrationBuilder.RenameTable(
                name: "Docente",
                newName: "Docentes");

            migrationBuilder.RenameIndex(
                name: "IX_Docente_AlumnoId",
                table: "Docentes",
                newName: "IX_Docentes_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Docentes",
                table: "Docentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Docentes_Alumnos_AlumnoId",
                table: "Docentes",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docentes_Alumnos_AlumnoId",
                table: "Docentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Docentes",
                table: "Docentes");

            migrationBuilder.RenameTable(
                name: "Docentes",
                newName: "Docente");

            migrationBuilder.RenameIndex(
                name: "IX_Docentes_AlumnoId",
                table: "Docente",
                newName: "IX_Docente_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Docente",
                table: "Docente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_Alumnos_AlumnoId",
                table: "Docente",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
