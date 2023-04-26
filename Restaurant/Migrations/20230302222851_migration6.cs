using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionNewsletterDec",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionContactUTitle",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionBookTableTitle",
                table: "TransactionBookTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingEmail",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingPhoneNumber",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterContactUsInformationTitle",
                table: "MasterContactUsInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "breadcrumb_areaName",
                table: "breadcrumb_area",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionNewsletterDec",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "TransactionContactUTitle",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "TransactionBookTableTitle",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "SystemSettingEmail",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SystemSettingPhoneNumber",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "MasterContactUsInformationTitle",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "breadcrumb_areaName",
                table: "breadcrumb_area");
        }
    }
}
