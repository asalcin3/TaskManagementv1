using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnusedPropertiesMiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromEmail",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RetryCount",
                schema: "dbo",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToSendOn",
                schema: "dbo",
                table: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "From",
                schema: "dbo",
                table: "Messages",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromEmail",
                schema: "dbo",
                table: "Messages",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RetryCount",
                schema: "dbo",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToSendOn",
                schema: "dbo",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
