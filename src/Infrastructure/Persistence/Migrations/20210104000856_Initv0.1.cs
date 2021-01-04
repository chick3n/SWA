using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SWA.Infrastructure.Persistence.Migrations
{
    public partial class Initv01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SiteCollections");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "DiscoveryObjects",
                newName: "RelativePath");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "SiteCollections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "SiteCollections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "SiteCollections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "DiscoveryObjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "DiscoveryObjects",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "SiteCollections");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "SiteCollections");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "SiteCollections");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "DiscoveryObjects");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "DiscoveryObjects");

            migrationBuilder.RenameColumn(
                name: "RelativePath",
                table: "DiscoveryObjects",
                newName: "Url");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SiteCollections",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }
    }
}
