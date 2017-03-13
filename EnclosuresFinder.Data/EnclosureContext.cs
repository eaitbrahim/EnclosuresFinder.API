using EnclosuresFinder.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnclosuresFinder.Data
{
    public class EnclosureContext: DbContext
    {
        public DbSet<Enclosure> Enclosures { get; set; }

        public EnclosureContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            modelBuilder.Entity<Enclosure>()
                .ToTable("Enclosure");

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.LengthIn)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.WidthIn)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.DepthIn)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.LengthMm)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.WidthMm)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.DepthMm)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.Material)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.IngressProtection)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.OutdoorUse)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.UlApproval)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.Nema4X)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.Series)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.TypeNumber)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.PartNumber)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.Description)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.ImageUrl)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.PdfUrl)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.DrawingUrl)
                .IsRequired();

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.ModelUrl)
                .IsRequired();
        }
    }
}
