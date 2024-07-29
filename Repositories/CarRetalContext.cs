using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities; // Add this using directive for the Entities namespace


namespace Repositories;

    public partial class CarRetalContext : DbContext
    {
        public CarRetalContext()
        {
        }

        public CarRetalContext(DbContextOptions<CarRetalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Landlord> Landlords { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<Renting> Rentings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=CAR_RETAL;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId).HasName("PK_Car");

                entity.ToTable("CAR");

                entity.Property(e => e.CarId).HasColumnName("CAR_ID");
                entity.Property(e => e.CarNumber).HasColumnName("CAR_NUMBER");
                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("COLOR");
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .HasColumnName("IMAGE_URL");
                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");
                entity.Property(e => e.NumOfKilometraz).HasColumnName("NUM_OF_KILOMETRAZ");
                entity.Property(e => e.Price).HasColumnName("PRICE");
                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.HasOne(d => d.Model).WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_CAR");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("COMPANY");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("COMPANY_NAME");
            });

            modelBuilder.Entity<Landlord>(entity =>
            {
                entity.ToTable("LANDLORD");

                entity.Property(e => e.LandlordId).HasColumnName("LANDLORD_ID");
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS");
                entity.Property(e => e.Birthdate).HasColumnName("BIRTHDATE");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.LandlordName)
                    .HasMaxLength(50)
                    .HasColumnName("LANDLORD_NAME");
                entity.Property(e => e.LandlordPhone)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("LANDLORD_PHONE");
                entity.Property(e => e.LandlordTz).HasColumnName("LANDLORD_TZ");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("MODEL");

                entity.Property(e => e.ModelId).HasColumnName("MODEL_ID");
                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");
                entity.Property(e => e.ManufactureYear).HasColumnName("MANUFACTURE_YEAR");
                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .HasColumnName("MODEL_NAME");
                entity.Property(e => e.NumOfSeats).HasColumnName("NUM_OF_SEATS");

                entity.HasOne(d => d.Company).WithMany(p => p.Models)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_MODEL");
            });

            modelBuilder.Entity<Renting>(entity =>
            {
                entity.ToTable("RENTING");

                entity.Property(e => e.RentingId).HasColumnName("RENTING_ID");
                entity.Property(e => e.AddDriver).HasColumnName("ADD_DRIVER");
                entity.Property(e => e.BabySeat).HasColumnName("BABY_SEAT");
                entity.Property(e => e.CarId).HasColumnName("CAR_ID");
                entity.Property(e => e.Damages).HasColumnName("DAMAGES");
                entity.Property(e => e.EarlyPayment).HasColumnName("EARLY_PAYMENT");
                entity.Property(e => e.Koster).HasColumnName("KOSTER");
                entity.Property(e => e.LandlordId).HasColumnName("LANDLORD_ID");
                entity.Property(e => e.RentingDate).HasColumnName("RENTING_DATE");
                entity.Property(e => e.ReturnDate).HasColumnName("RETURN_DATE");
                entity.Property(e => e.TotalPayment).HasColumnName("TOTAL_PAYMENT");
                entity.Property(e => e.Wase).HasColumnName("WASE");

                entity.HasOne(d => d.Car).WithMany(p => p.Rentings)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_RENTINGID1");

                entity.HasOne(d => d.Landlord).WithMany(p => p.Rentings)
                    .HasForeignKey(d => d.LandlordId)
                    .HasConstraintName("FK_RENTINGID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
