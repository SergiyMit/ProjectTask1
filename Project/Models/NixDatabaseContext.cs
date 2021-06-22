using System;
using Lecture2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project
{
    public partial class NixDatabaseContext : DbContext
    {
        public NixDatabaseContext()
        {
        }

        public NixDatabaseContext(DbContextOptions<NixDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CertificateLevel> CertificateLevels { get; set; }
        public virtual DbSet<DiveCertificate> DiveCertificates { get; set; }
        public virtual DbSet<DiveMeasurement> DiveMeasurements { get; set; }
        public virtual DbSet<Diver> Divers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-MUQMAF1\\MITRIAIEV;Database=NixDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Admins__4C3F97F4418229DD");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Admins__IdUser__628FA481");
            });

            modelBuilder.Entity<CertificateLevel>(entity =>
            {
                entity.HasKey(e => e.IdLevel)
                    .HasName("PK__Certific__A4740DB4E4D2EB82");

                entity.ToTable("CertificateLevel");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiveCertificate>(entity =>
            {
                entity.HasKey(e => e.IdCertificate)
                    .HasName("PK__DiveCert__F584061F1FCB8589");

                entity.ToTable("DiveCertificate");

                entity.Property(e => e.CertNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfIssuance).HasColumnType("datetime");

                entity.HasOne(d => d.IdDiverNavigation)
                    .WithMany(p => p.DiveCertificates)
                    .HasForeignKey(d => d.IdDiver)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DiveCerti__IdDiv__5CD6CB2B");

                entity.HasOne(d => d.IdLevelNavigation)
                    .WithMany(p => p.DiveCertificates)
                    .HasForeignKey(d => d.IdLevel)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DiveCerti__IdLev__5BE2A6F2");
            });

            modelBuilder.Entity<DiveMeasurement>(entity =>
            {
                entity.HasKey(e => e.IdMeasurement)
                    .HasName("PK__DiveMeas__23A192E2FE94FBFE");

                entity.ToTable("DiveMeasurement");

                entity.Property(e => e.DateOfDive).HasColumnType("datetime");

                entity.Property(e => e.WaterTemperature).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdDiverNavigation)
                    .WithMany(p => p.DiveMeasurements)
                    .HasForeignKey(d => d.IdDiver)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DiveMeasu__IdDiv__5FB337D6");
            });

            modelBuilder.Entity<Diver>(entity =>
            {
                entity.HasKey(e => e.IdDiver)
                    .HasName("PK__Divers__5E34ECEB007B2C93");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Divers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Divers__IdUser__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C92638C1A01659");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
