using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWorkoutTracker.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addIsFinishedToWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Workouts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Workouts");
        }
    }
}
