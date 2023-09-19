using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Merchandising.Domain.HrmsModels
{
    public partial class CoreERPContext : DbContext
    {
        public CoreERPContext(DbContextOptions<CoreERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttendanceDailyPunchRecord> AttendanceDailyPunchRecords { get; set; }
        public virtual DbSet<CommonCompany> CommonCompanies { get; set; }
        public virtual DbSet<CommonUnit> CommonUnits { get; set; }
        public virtual DbSet<HumanResourceEmployeeBasic> HumanResourceEmployeeBasics { get; set; }
        public virtual DbSet<OgranogramApplicationsApproval> OgranogramApplicationsApprovals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceDailyPunchRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Attendance_DailyPunchRecord");

                entity.HasIndex(e => new { e.PunchTime, e.PunchNo }, "_dta_index_Attendance.DailyPunchRecord_5_978818549__K2_K1_3");

                entity.HasIndex(e => e.DoorMode, "_dta_index_Attendance.DailyPunchRecord_5_978818549__K4");

                entity.HasIndex(e => new { e.PunchNo, e.PunchTime }, "_dta_index_Attendance.DailyPunchRecord_c_5_978818549__K1_K2")
                    .IsClustered();

                entity.Property(e => e.ActionTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceNo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DoorMode).HasComment("0=In Mood,1= Out Mood");

                entity.Property(e => e.InActiveDate).HasColumnType("datetime");

                entity.Property(e => e.PunchTime).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CommonCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK_Common.Company");

                entity.ToTable("Common_Company");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyNameBan).HasMaxLength(50);

                entity.Property(e => e.CompanyShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
            });

            modelBuilder.Entity<CommonUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK_Common.Unit");

                entity.ToTable("Common_Unit");

                entity.HasIndex(e => e.UnitName, "IX_Common_Unit")
                    .IsUnique();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UnitAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNameBan).HasMaxLength(150);

                entity.Property(e => e.UnitShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitTypeId).HasComment("");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HumanResourceEmployeeBasic>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_HumanResource.EmployeeBasic_1");

                entity.ToTable("HumanResource_EmployeeBasic");

                entity.HasIndex(e => e.EmpCode, "_dta_index_HumanResource.EmployeeBasic_5_1394820031__K2_1")
                    .IsUnique();

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.Bgmeaid)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("BGMEAID");

                entity.Property(e => e.BirthCertificateNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroupId).HasColumnName("BloodGroupID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.EmpCategoryId).HasColumnName("EmpCategoryID");

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.EmpStatusId)
                    .HasColumnName("EmpStatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpTypeId).HasColumnName("EmpTypeID");

                entity.Property(e => e.FathersName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinalSubmitDate).HasColumnType("date");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsertUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InsertUserID");

                entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");

                entity.Property(e => e.JoiningDate).HasColumnType("date");

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.MothersName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameBan).HasMaxLength(50);

                entity.Property(e => e.NationalityId).HasColumnName("NationalityID");

                entity.Property(e => e.Nidno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NIDNo");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PrevEmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PrevEmpID");

                entity.Property(e => e.PrevPunchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProbationDate).HasColumnType("date");

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.RollBackDate).HasColumnType("datetime");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TerminalID");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TitleBan).HasMaxLength(50);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UpdateUserID");

                entity.Property(e => e.WingId).HasColumnName("WingID");
            });

            modelBuilder.Entity<OgranogramApplicationsApproval>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ogranogram_ApplicationsApproval");

                entity.Property(e => e.EffectDate).HasColumnType("date");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InActiveDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
