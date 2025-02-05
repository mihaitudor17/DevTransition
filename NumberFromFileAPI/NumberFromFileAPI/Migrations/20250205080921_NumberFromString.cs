using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumberFromFileAPI.Migrations
{
    /// <inheritdoc />
    public partial class NumberFromString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "FileModels",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "FileModels",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
