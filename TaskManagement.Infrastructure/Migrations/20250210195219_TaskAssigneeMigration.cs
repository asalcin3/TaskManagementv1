using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaskAssigneeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDue",
                schema: "dbo",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TaskAssignee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeAssigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssignee_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "dbo",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignee_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignee_TaskId",
                schema: "dbo",
                table: "TaskAssignee",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignee_UserId",
                schema: "dbo",
                table: "TaskAssignee",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskAssignee",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "DateDue",
                schema: "dbo",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Tasks");
        }
    }
}
