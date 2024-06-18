using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackSystem.Persistence.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedByColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "feedback");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "feedback",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
