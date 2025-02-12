using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MissingMigrations : Migration
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
                name: "EmailTemplates",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    EmailTemplate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "varchar(500)", nullable: false),
                    Body = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    ToSendOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WasSentOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeliveryMethod = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    EmailTemplateType = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<string>(type: "varchar(200)", nullable: false),
                    FromEmail = table.Column<string>(type: "varchar(255)", nullable: false),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: true),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignees",
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
                    table.PrimaryKey("PK_TaskAssignees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssignees_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "dbo",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignees_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_EmailTemplate",
                schema: "dbo",
                table: "EmailTemplates",
                column: "EmailTemplate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                schema: "dbo",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                schema: "dbo",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignees_TaskId",
                schema: "dbo",
                table: "TaskAssignees",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignees_UserId",
                schema: "dbo",
                table: "TaskAssignees",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TaskAssignees",
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
