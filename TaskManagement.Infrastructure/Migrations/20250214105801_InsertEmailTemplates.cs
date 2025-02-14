using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertEmailTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var bodyCreate = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Task Created</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; margin: 0; }
        .container { max-width: 600px; background: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); margin: auto; }
        h2 { color: #333; text-align: center; }
        p { color: #555; line-height: 1.6; }
        .button { display: inline-block; background: #28a745; color: #ffffff; padding: 12px 18px; text-decoration: none; border-radius: 5px; font-weight: bold; text-align: center; margin-top: 10px; }
        .footer { margin-top: 20px; font-size: 12px; color: #777; text-align: center; }
    </style>
</head>
<body>
    <div class=""container"">
        <h2>New Task Created</h2>
        <p>Hello <strong>%userName%</strong>,</p>
        <p>A new task has been assigned to you.</p>
        <p>Please check it for more details.</p>
        <div style=""text-align: center;"">
            <a href=""%taskLink%"" class=""button"">View Task</a>
        </div>
        <p class=""footer"">Best Regards,<br>Your Team</p>
    </div>
</body>
</html>";

            var bodyComplete = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Task Completed</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; margin: 0; }
        .container { max-width: 600px; background: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); margin: auto; }
        h2 { color: #333; text-align: center; }
        p { color: #555; line-height: 1.6; }
        .button { display: inline-block; background: #28a745; color: #ffffff; padding: 12px 18px; text-decoration: none; border-radius: 5px; font-weight: bold; text-align: center; margin-top: 10px; }
        .footer { margin-top: 20px; font-size: 12px; color: #777; text-align: center; }
    </style>
</head>
<body>
    <div class=""container"">
        <h2>Task Completed</h2>
        <p>Hello <strong>%userName%</strong>,</p>
        <p>A task assigned to you has been marked as completed.</p>
        <p>Please check it for more details.</p>
        <div style=""text-align: center;"">
            <a href=""%taskLink%"" class=""button"">View Task</a>
        </div>
        <p class=""footer"">Best Regards,<br>Your Team</p>
    </div>
</body>
</html>";

            var bodyDelete = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Task Deleted</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; margin: 0; }
        .container { max-width: 600px; background: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); margin: auto; }
        h2 { color: #333; text-align: center; }
        p { color: #555; line-height: 1.6; }
        .footer { margin-top: 20px; font-size: 12px; color: #777; text-align: center; }
    </style>
</head>
<body>
    <div class=""container"">
        <h2>Task Deleted</h2>
        <p>Hello <strong>%userName%</strong>,</p>
        <p>A task with ID <strong>%taskId%</strong> has been deleted.</p>
        <p>If this was unexpected, please contact support.</p>
        <p class=""footer"">Best Regards,<br>Your Team</p>
    </div>
</body>
</html>";

            bodyCreate = bodyCreate.Replace("'", "''");
            bodyComplete = bodyComplete.Replace("'", "''");
            bodyDelete = bodyDelete.Replace("'", "''");

            var script = $"INSERT INTO EmailTemplates (Subject, Body, EmailTemplate) " +
                         $"VALUES " +
                         $"('Task Created', '{bodyCreate}', 1), " +
                         $"('Task Deleted', '{bodyDelete}', 2), " +
                         $"('Task Completed', '{bodyComplete}', 3)";

            migrationBuilder.Sql(script);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
