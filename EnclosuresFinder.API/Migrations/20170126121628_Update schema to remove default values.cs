using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnclosuresFinder.API.Migrations
{
    public partial class Updateschematoremovedefaultvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UlApproval",
                table: "Enclosure",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Series",
                table: "Enclosure",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "OutdoorUse",
                table: "Enclosure",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Nema4X",
                table: "Enclosure",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Material",
                table: "Enclosure",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "IngressProtection",
                table: "Enclosure",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UlApproval",
                table: "Enclosure",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "Series",
                table: "Enclosure",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "OutdoorUse",
                table: "Enclosure",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Nema4X",
                table: "Enclosure",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "Material",
                table: "Enclosure",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "IngressProtection",
                table: "Enclosure",
                nullable: false,
                defaultValue: 1);
        }
    }
}
