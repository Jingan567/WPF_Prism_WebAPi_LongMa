using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class 使用sqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Account = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.AccountId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInfo");
        }
    }
}
