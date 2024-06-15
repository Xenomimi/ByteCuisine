using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteCuisine.Server.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "ByteCuisine",
                table: "Account",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                schema: "ByteCuisine",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                schema: "ByteCuisine",
                table: "Account",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_Email",
                schema: "ByteCuisine",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_Username",
                schema: "ByteCuisine",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "ByteCuisine",
                table: "Account");
        }
    }
}
