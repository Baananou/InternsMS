using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternsMS.Migrations
{
    /// <inheritdoc />
    public partial class updatedallmodelsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternInternship");

            migrationBuilder.AddColumn<int>(
                name: "InternshipId",
                table: "Interns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interns_InternshipId",
                table: "Interns",
                column: "InternshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interns_Internships_InternshipId",
                table: "Interns",
                column: "InternshipId",
                principalTable: "Internships",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interns_Internships_InternshipId",
                table: "Interns");

            migrationBuilder.DropIndex(
                name: "IX_Interns_InternshipId",
                table: "Interns");

            migrationBuilder.DropColumn(
                name: "InternshipId",
                table: "Interns");

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
                name: "IX_InternInternship_InternshipsId",
                table: "InternInternship",
                column: "InternshipsId");
        }
    }
}
