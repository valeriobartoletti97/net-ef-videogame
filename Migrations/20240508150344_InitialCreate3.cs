using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tax_Id",
                table: "software_houses",
                newName: "tax_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "software_houses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "software_houses",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "software_houses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "software_houses",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "software_houses",
                newName: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tax_id",
                table: "software_houses",
                newName: "tax_Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "software_houses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "software_houses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "software_houses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "software_houses",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "software_houses",
                newName: "CreatedAt");
        }
    }
}
