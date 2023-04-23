using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsMS.Migrations
{
    /// <inheritdoc />
    public partial class updatedallmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Supervisors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Supervisors",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Supervisors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Internships",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Interns",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Interns",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "EvaluationSheets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "EvaluationSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InternId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InternInternship",
                columns: table => new
                {
                    InternsId = table.Column<int>(type: "int", nullable: false),
                    InternshipsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternInternship", x => new { x.InternsId, x.InternshipsId });
                    table.ForeignKey(
                        name: "FK_InternInternship_Interns_InternsId",
                        column: x => x.InternsId,
                        principalTable: "Interns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternInternship_Internships_InternshipsId",
                        column: x => x.InternshipsId,
                        principalTable: "Internships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Internships_SupervisorId",
                table: "Internships",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationSheets_SupervisorId",
                table: "EvaluationSheets",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_InternId",
                table: "Assignments",
                column: "InternId");

            migrationBuilder.CreateIndex(
                name: "IX_InternInternship_InternshipsId",
                table: "InternInternship",
                column: "InternshipsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Interns_InternId",
                table: "Assignments",
                column: "InternId",
                principalTable: "Interns",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationSheets_Supervisors_SupervisorId",
                table: "EvaluationSheets",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Supervisors_SupervisorId",
                table: "Internships",
                column: "SupervisorId",
                principalTable: "Supervisors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Interns_InternId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationSheets_Supervisors_SupervisorId",
                table: "EvaluationSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Supervisors_SupervisorId",
                table: "Internships");

            migrationBuilder.DropTable(
                name: "InternInternship");

            migrationBuilder.DropIndex(
                name: "IX_Internships_SupervisorId",
                table: "Internships");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationSheets_SupervisorId",
                table: "EvaluationSheets");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_InternId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Supervisors");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "EvaluationSheets");

            migrationBuilder.DropColumn(
                name: "InternId",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Interns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Interns",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "EvaluationSheets",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
