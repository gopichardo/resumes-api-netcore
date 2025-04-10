using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProfessionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Proffesion_ProffesionId",
                table: "Skill");

            migrationBuilder.DropTable(
                name: "Proffesion");

            migrationBuilder.DropIndex(
                name: "IX_Skill_ProffesionId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ProffesionId",
                table: "Skill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProffesionId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proffesion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proffesion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proffesion_Resume_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resume",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ProffesionId",
                table: "Skill",
                column: "ProffesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Proffesion_ResumeId",
                table: "Proffesion",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Proffesion_ProffesionId",
                table: "Skill",
                column: "ProffesionId",
                principalTable: "Proffesion",
                principalColumn: "Id");
        }
    }
}
