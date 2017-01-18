using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnclosuresFinder.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepthIn = table.Column<double>(nullable: false),
                    DepthMm = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    DrawingUrl = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    IngressProtection = table.Column<int>(nullable: false, defaultValue: 1),
                    LengthIn = table.Column<double>(nullable: false),
                    LengthMm = table.Column<double>(nullable: false),
                    Material = table.Column<int>(nullable: false, defaultValue: 1),
                    ModelUrl = table.Column<string>(nullable: false),
                    Nema4X = table.Column<bool>(nullable: false, defaultValue: true),
                    OutdoorUse = table.Column<bool>(nullable: false, defaultValue: true),
                    PartNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PdfUrl = table.Column<string>(nullable: false),
                    Series = table.Column<int>(nullable: false, defaultValue: 1),
                    TypeNumber = table.Column<string>(maxLength: 50, nullable: false),
                    UlApproval = table.Column<bool>(nullable: false, defaultValue: true),
                    WidthIn = table.Column<double>(nullable: false),
                    WidthMm = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosure", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enclosure");
        }
    }
}
