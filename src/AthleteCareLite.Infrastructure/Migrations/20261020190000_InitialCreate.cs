using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AthleteCareLite.Infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AthleteProfiles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                School = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                GraduationYear = table.Column<int>(type: "int", nullable: false),
                PrimarySport = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AthleteProfiles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "CoachNotes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AthleteId = table.Column<int>(type: "int", nullable: false),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                NoteText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CoachNotes", x => x.Id);
                table.ForeignKey(
                    name: "FK_CoachNotes_AthleteProfiles_AthleteId",
                    column: x => x.AthleteId,
                    principalTable: "AthleteProfiles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "DailyWellnessCheckIns",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AthleteId = table.Column<int>(type: "int", nullable: false),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                SleepHours = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                SorenessLevel = table.Column<int>(type: "int", nullable: false),
                Mood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                ReadinessScore = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DailyWellnessCheckIns", x => x.Id);
                table.ForeignKey(
                    name: "FK_DailyWellnessCheckIns_AthleteProfiles_AthleteId",
                    column: x => x.AthleteId,
                    principalTable: "AthleteProfiles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TrainingSessionLogs",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AthleteId = table.Column<int>(type: "int", nullable: false),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                Activity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                DurationMinutes = table.Column<int>(type: "int", nullable: false),
                Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrainingSessionLogs", x => x.Id);
                table.ForeignKey(
                    name: "FK_TrainingSessionLogs_AthleteProfiles_AthleteId",
                    column: x => x.AthleteId,
                    principalTable: "AthleteProfiles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CoachNotes_AthleteId",
            table: "CoachNotes",
            column: "AthleteId");

        migrationBuilder.CreateIndex(
            name: "IX_DailyWellnessCheckIns_AthleteId",
            table: "DailyWellnessCheckIns",
            column: "AthleteId");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingSessionLogs_AthleteId",
            table: "TrainingSessionLogs",
            column: "AthleteId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "CoachNotes");
        migrationBuilder.DropTable(name: "DailyWellnessCheckIns");
        migrationBuilder.DropTable(name: "TrainingSessionLogs");
        migrationBuilder.DropTable(name: "AthleteProfiles");
    }
}
