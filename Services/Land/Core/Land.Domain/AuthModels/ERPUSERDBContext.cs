using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class ERPUSERDBContext : DbContext
    {
        public ERPUSERDBContext(DbContextOptions<ERPUSERDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ErpProject> ErpProjects { get; set; }
        public virtual DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public virtual DbSet<GroupMenuPermission> GroupMenuPermissions { get; set; }
        public virtual DbSet<LoginHistory> LoginHistories { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportPermission> ReportPermissions { get; set; }
        public virtual DbSet<UserAccessPermission> UserAccessPermissions { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserGroupPermission> UserGroupPermissions { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }
        public virtual DbSet<UserLevelMap> UserLevelMaps { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<UserTypeMap> UserTypeMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ErpProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("ERP_Project");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ForgotPassword>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ForgotPassword");

                entity.Property(e => e.EmpCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GroupMenuPermission>(entity =>
            {
                entity.HasKey(e => e.MenuPermissionId);

                entity.ToTable("GroupMenuPermission");

                entity.HasIndex(e => new { e.GroupId, e.MenuId }, "IX_GroupMenuPermission")
                    .IsUnique();
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.HasKey(e => e.Lhid);

                entity.ToTable("LoginHistory");

                entity.Property(e => e.Lhid).HasColumnName("LHId");

                entity.Property(e => e.Ipaddress)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.LogOutTime).HasColumnType("datetime");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.SessionId).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.ProjectId })
                    .HasName("PK_Menu_1");

                entity.ToTable("Menu");

                entity.Property(e => e.MenuId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MenuPath).HasMaxLength(200);

                entity.Property(e => e.Sororder).HasColumnName("SORORDER");

                entity.Property(e => e.Todo).HasColumnName("TODO");
            });

            modelBuilder.Entity<MenuPermission>(entity =>
            {
                entity.ToTable("MenuPermission");

                entity.HasIndex(e => new { e.MenuId, e.UserId }, "IX_MenuPermission")
                    .IsUnique()
                    .HasFillFactor((byte)90);

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => new { e.ModuleId, e.ProjectId });

                entity.ToTable("Module");

                entity.Property(e => e.ModuleId).ValueGeneratedOnAdd();

                entity.Property(e => e.IconColor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IconName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.MenuId });

                entity.HasIndex(e => new { e.ReportCode, e.MenuId }, "IX_Reports")
                    .IsUnique();

                entity.Property(e => e.ReportId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportPermission>(entity =>
            {
                entity.ToTable("ReportPermission");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccessPermission>(entity =>
            {
                entity.HasKey(e => e.AccessPermissionId)
                    .HasName("PK_UserAccessPermission_1");

                entity.ToTable("UserAccessPermission");

                entity.HasIndex(e => new { e.UserId, e.MenuId }, "IX_UserAccessPermission")
                    .IsUnique();

                entity.Property(e => e.CanDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.CanEdit).HasDefaultValueSql("((0))");

                entity.Property(e => e.CanInsert).HasDefaultValueSql("((0))");

                entity.Property(e => e.CanView).HasDefaultValueSql("((0))");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("UserGroup");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserGroupName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserGroupPermission>(entity =>
            {
                entity.HasKey(e => e.GroupPermissionId);

                entity.ToTable("UserGroupPermission");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_userinfo");

                entity.ToTable("UserInfo");

                entity.HasIndex(e => e.EmpId, "IX_UserInfo")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HrmisUser).HasColumnName("HRMIS_User");

                entity.Property(e => e.InvalidLoginTry).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('y')")
                    .IsFixedLength(true);

                entity.Property(e => e.IsItadmin).HasColumnName("IsITAdmin");

                entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSetPass).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.MerchandisingUser)
                    .HasColumnName("Merchandising_User")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RowDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsrDesig)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsrPass)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.ToTable("UserLevel");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserLevelName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLevelMap>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.ToTable("UserLevelMap");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTypeMap>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.ToTable("UserTypeMap");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
