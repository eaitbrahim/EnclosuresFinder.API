using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EnclosuresFinder.Data;

namespace EnclosuresFinder.API.Migrations
{
    [DbContext(typeof(EnclosureContext))]
    [Migration("20170126121628_Update schema to remove default values")]
    partial class Updateschematoremovedefaultvalues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnclosuresFinder.Model.Entities.Enclosure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("DepthIn");

                    b.Property<double>("DepthMm");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("DrawingUrl")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int>("IngressProtection");

                    b.Property<double>("LengthIn");

                    b.Property<double>("LengthMm");

                    b.Property<int>("Material");

                    b.Property<string>("ModelUrl")
                        .IsRequired();

                    b.Property<bool>("Nema4X");

                    b.Property<bool>("OutdoorUse");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("PdfUrl")
                        .IsRequired();

                    b.Property<int>("Series");

                    b.Property<string>("TypeNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("UlApproval");

                    b.Property<double>("WidthIn");

                    b.Property<double>("WidthMm");

                    b.HasKey("Id");

                    b.ToTable("Enclosure");
                });
        }
    }
}
