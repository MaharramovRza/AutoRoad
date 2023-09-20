using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRoad.MVC.Migrations
{
    /// <inheritdoc />
    public partial class IsMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "CarPhotos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "CarPhotos");
        }
    }
}
