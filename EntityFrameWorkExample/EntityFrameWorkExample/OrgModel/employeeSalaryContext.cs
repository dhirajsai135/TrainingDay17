using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFrameWorkExample.OrgModel
{
    public partial class employeeSalaryContext : DbContext
    {
        public employeeSalaryContext()
        {
        }

        public employeeSalaryContext(DbContextOptions<employeeSalaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<EmpSalary> EmpSalaries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<TransactionE> TransactionEs { get; set; }
        public virtual DbSet<Urkne> Urknes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-1S1CRF3N\\SQLEXPRESS01;Database=employeeSalary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("account");

                entity.Property(e => e.AccNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("acc_number");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('open')");
            });

            modelBuilder.Entity<EmpSalary>(entity =>
            {
                entity.HasKey(e => e.TranscNum)
                    .HasName("pkey");

                entity.ToTable("empSalary");

                entity.HasIndex(e => new { e.EmpId, e.SalId, e.Date }, "unq")
                    .IsUnique();

                entity.Property(e => e.TranscNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("transc_num");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.SalId).HasColumnName("sal_id");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpSalaries)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__empSalary__emp_i__3C69FB99");

                entity.HasOne(d => d.Sal)
                    .WithMany(p => p.EmpSalaries)
                    .HasForeignKey(d => d.SalId)
                    .HasConstraintName("FK__empSalary__sal_i__3D5E1FD2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__1299A86117F4FD11");

                entity.ToTable("employee");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasDefaultValueSql("((18))");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.SalId)
                    .HasName("PK__Salary__FEF11768F779CF79");

                entity.ToTable("Salary");

                entity.Property(e => e.SalId).HasColumnName("sal_id");

                entity.Property(e => e.BasicSal).HasColumnName("basic_sal");

                entity.Property(e => e.Da).HasColumnName("da");

                entity.Property(e => e.Deduction).HasColumnName("deduction");

                entity.Property(e => e.Hra).HasColumnName("hra");
            });

            modelBuilder.Entity<TransactionE>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transaction_e");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.FromAcc).HasColumnName("from_acc");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.ToAcc).HasColumnName("to_acc");

                entity.Property(e => e.TrainId).HasColumnName("train_id");
            });

            modelBuilder.Entity<Urkne>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("urkne");

                entity.Property(e => e.Fun).HasColumnName("fun");

                entity.Property(e => e.Name)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
