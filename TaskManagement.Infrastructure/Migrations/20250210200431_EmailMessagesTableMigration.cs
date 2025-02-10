using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmailMessagesTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
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
                    Priority = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_Users_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                schema: "dbo",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                schema: "dbo",
                table: "Message",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message",
                schema: "dbo");
        }
    }
}
