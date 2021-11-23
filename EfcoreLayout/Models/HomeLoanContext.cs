using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


#nullable disable

namespace EfcoreLayout.Models
{
    public partial class HomeLoanContext : DbContext
    {
        public HomeLoanContext()
        {
        }

        public HomeLoanContext(DbContextOptions<HomeLoanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<IncomeDetail> IncomeDetails { get; set; }
        public virtual DbSet<LoanDetail> LoanDetails { get; set; }
        public virtual DbSet<LoanStatus> LoanStatuses { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<UploadedDocument> UploadedDocuments { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VVPGI1R\\SQLExpress;Database=HomeLoan; User Id=sa;Password=newuser123;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("Admin_ID");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Password");
            });

            modelBuilder.Entity<IncomeDetail>(entity =>
            {
                entity.HasKey(e => e.IncomeId)
                    .HasName("PK__Income_D__344C937946216EB8");

                entity.ToTable("Income_Details");

                entity.Property(e => e.IncomeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Income_ID");

                entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Organization_Name");

                entity.Property(e => e.OrganizationType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Organization_Type");

                entity.Property(e => e.RetirementAge).HasColumnName("Retirement_Age");

                entity.Property(e => e.TypeOfEmployment)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Type_Of_Employment");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.IncomeDetails)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Income_De__Appli__3D5E1FD2");
            });

            modelBuilder.Entity<LoanDetail>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK__Loan_Det__937E27D3382094B3");

                entity.ToTable("Loan_Details");

                entity.Property(e => e.LoanId)
                    .ValueGeneratedNever()
                    .HasColumnName("Loan_ID");

                entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");

                entity.Property(e => e.InterestRate).HasColumnName("Interest_rate");

                
                entity.Property(e => e.LoanDate)
                    .HasColumnType("date")
                    .HasColumnName("Loan_Date");

                entity.Property(e => e.MaxAmountGrantable).HasColumnName("Max_amount_grantable");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Loan_Deta__Appli__403A8C7D");
            });

            modelBuilder.Entity<LoanStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__Loan_Sta__519009ACFE81608B");

                entity.ToTable("Loan_Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Status_ID");

                entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");

                entity.Property(e => e.TrackStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Track_Status");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.LoanStatuses)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Loan_Stat__Appli__45F365D3");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.PropertyId)
                    .ValueGeneratedNever()
                    .HasColumnName("Property_ID");

                entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");

                entity.Property(e => e.EstimatedCost).HasColumnName("Estimated_Cost");

                entity.Property(e => e.PropertyArea)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Property_Area");

                entity.Property(e => e.PropertyNumber).HasColumnName("Property_Number");

                entity.Property(e => e.TypeOfProperty)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Type_Of_Property");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Property__Applic__3A81B327");
            });

            modelBuilder.Entity<UploadedDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK__Uploaded__513A0475D99CCFA4");

                entity.ToTable("Uploaded_Documents");

                entity.Property(e => e.DocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Document_ID");

                entity.Property(e => e.AadharCard)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Aadhar_Card");

                entity.Property(e => e.Agreement)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");

                entity.Property(e => e.DocumentverifiedStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Documentverified_status");

                entity.Property(e => e.Loa)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Noc)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.PanCard)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Pan_Card");

                entity.Property(e => e.SalarySlip)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Salary_Slip");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.UploadedDocuments)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Uploaded___Appli__4316F928");

                entity.Property(e => e.LoanApprovalStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LoanApprovalStatus");

            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__User_Det__E063E1CBF6303E2A");

                entity.ToTable("User_Details");

                entity.Property(e => e.ApplicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("Application_ID");

                entity.Property(e => e.AadharNumber).HasColumnName("Aadhar_Number");

                entity.Property(e => e.BankAccountNumber).HasColumnName("Bank_Account_Number");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PanNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Pan_Number");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        
    }
}
