using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class liuliu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "AccountInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                table: "AccountInfo");
        }
    }
}
