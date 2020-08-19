using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vita.Persistance.Sql.Migrations
{
    public partial class AddedDescriptionAndCreateOnGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Goals",
                nullable: true);

            DateTimeOffset dateTime = DateTimeOffset.UtcNow;

            migrationBuilder.Sql($"Update Goals set CreatedOn = '{dateTime}'");

            migrationBuilder.AlterColumn<DateTimeOffset>("CreatedOn", table: "Goals", nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Goals",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOn",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Goals");
        }
    }
}
