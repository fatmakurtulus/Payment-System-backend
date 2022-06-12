using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using PaymentSys.Entity.Models;

#nullable disable

namespace PaymentSys.Dal.Concrete.EntityFramework.Context
{
    public partial class PaymentSysContext : DbContext
    {
        IConfiguration configuration;
        public PaymentSysContext(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        //public PaymentSysContext(DbContextOptions<PaymentSysContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            //            if (!optionsBuilder.IsConfigured)
            //            {
            ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=LAPTOP-G9IER4GV\\SQLEXPRESS2017;Database=PaymentSys;Trusted_Connection=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => e.ApartId);

                entity.ToTable("Apartment");

                entity.Property(e => e.ApartId)
                    .ValueGeneratedNever()
                    .HasColumnName("apartID");

                entity.Property(e => e.ApartFloor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("apartFloor");

                entity.Property(e => e.ApartIsFull).HasColumnName("apartIsFull");

                entity.Property(e => e.ApartNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("apartNumber");

                entity.Property(e => e.ApartOwnerTc).HasColumnName("apartOwnerTc");

                entity.Property(e => e.ApartType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apartType");

                entity.Property(e => e.Apartblock)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("apartblock");

                entity.HasOne(d => d.ApartOwnerTcNavigation)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.ApartOwnerTc)
                    .HasConstraintName("FK_Apartment_User");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("paymentID");

                entity.Property(e => e.FinishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("finishDate");

                entity.Property(e => e.PaymentIsPaid).HasColumnName("paymentIsPaid");

                entity.Property(e => e.PaymentOwnerTc).HasColumnName("paymentOwnerTC");

                entity.Property(e => e.PaymentTotal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("paymentTotal");

                entity.Property(e => e.PaymentType).HasColumnName("paymentType");

                entity.HasOne(d => d.PaymentOwnerTcNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentOwnerTc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_User");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentType");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeID");

                entity.Property(e => e.PaymentTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("paymentTypeName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Tc);

                entity.ToTable("User");

                entity.Property(e => e.Tc)
                    .ValueGeneratedNever()
                    .HasColumnName("TC");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PlateNumber)
                    .HasMaxLength(30)
                    .HasColumnName("plateNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
