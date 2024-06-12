using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLawyerIdToCaseFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LawyerName",
                table: "Lawyers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CaseFileName",
                table: "CaseFiles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "LawyerId",
                table: "CaseFiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LawyerName",
                table: "CaseFiles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LawyerId",
                table: "CaseFiles");

            migrationBuilder.DropColumn(
                name: "LawyerName",
                table: "CaseFiles");

            migrationBuilder.AlterColumn<string>(
                name: "LawyerName",
                table: "Lawyers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CaseFileName",
                table: "CaseFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
