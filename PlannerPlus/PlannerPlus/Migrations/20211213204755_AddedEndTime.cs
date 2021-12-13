using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannerPlus.Migrations
{
    public partial class AddedEndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeviceTime",
                table: "Records",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Records",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Records",
                newName: "SeviceTime");
        }
    }
}
