using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budzet.Migrations
{
    /// <inheritdoc />
    public partial class Osoby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PersonId",
                table: "Transaction",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Person_PersonId",
                table: "Transaction",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Person_PersonId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_PersonId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Transaction");
        }
    }
}
