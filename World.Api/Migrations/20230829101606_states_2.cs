using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace World.Api.Migrations
{
    /// <inheritdoc />
    public partial class states_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "States",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "States",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "States",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "States",
                newName: "id");
        }
    }
}
