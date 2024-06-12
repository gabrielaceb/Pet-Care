using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "PetDetails",
                type: "float",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "PetDetails",
                type: "float",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 32);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "PetDetails",
                type: "real",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "PetDetails",
                type: "real",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 32);
        }
    }
}
