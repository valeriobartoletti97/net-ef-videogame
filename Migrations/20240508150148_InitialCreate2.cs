using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_houses_SoftwareHouseId",
                table: "videogames");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "videogames",
                newName: "overview");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "videogames",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "videogames",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "videogames",
                newName: "software_house_id");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "videogames",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "videogames",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "VideogameId",
                table: "videogames",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_VideogameId",
                table: "videogames",
                newName: "IX_videogames_id");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_SoftwareHouseId",
                table: "videogames",
                newName: "IX_videogames_software_house_id");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "software_houses",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_software_houses_SoftwareHouseId",
                table: "software_houses",
                newName: "IX_software_houses_id");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_houses_software_house_id",
                table: "videogames",
                column: "software_house_id",
                principalTable: "software_houses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_houses_software_house_id",
                table: "videogames");

            migrationBuilder.RenameColumn(
                name: "overview",
                table: "videogames",
                newName: "Overview");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "videogames",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "videogames",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "software_house_id",
                table: "videogames",
                newName: "SoftwareHouseId");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "videogames",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "videogames",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "videogames",
                newName: "VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_software_house_id",
                table: "videogames",
                newName: "IX_videogames_SoftwareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_id",
                table: "videogames",
                newName: "IX_videogames_VideogameId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "software_houses",
                newName: "SoftwareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_software_houses_id",
                table: "software_houses",
                newName: "IX_software_houses_SoftwareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_houses_SoftwareHouseId",
                table: "videogames",
                column: "SoftwareHouseId",
                principalTable: "software_houses",
                principalColumn: "SoftwareHouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
