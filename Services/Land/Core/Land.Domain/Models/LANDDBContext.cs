using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Land.Domain.Models
{
    public partial class LANDDBContext : DbContext
    {
        public LANDDBContext()
        {
        }

        public LANDDBContext(DbContextOptions<LANDDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlmirahNoInfo> AlmirahNoInfos { get; set; }
        public virtual DbSet<BayaDeedDetail> BayaDeedDetails { get; set; }
        public virtual DbSet<CmnBanglaYear> CmnBanglaYears { get; set; }
        public virtual DbSet<CmnDistrict> CmnDistricts { get; set; }
        public virtual DbSet<CmnDivision> CmnDivisions { get; set; }
        public virtual DbSet<CmnDocumentFile> CmnDocumentFiles { get; set; }
        public virtual DbSet<CmnMouza> CmnMouzas { get; set; }
        public virtual DbSet<CmnSubRegOffice> CmnSubRegOffices { get; set; }
        public virtual DbSet<CmnUpozila> CmnUpozilas { get; set; }
        public virtual DbSet<FileCodeInfo> FileCodeInfos { get; set; }
        public virtual DbSet<FileLocationDetail> FileLocationDetails { get; set; }
        public virtual DbSet<FileLocationMaster> FileLocationMasters { get; set; }
        public virtual DbSet<FileNoInfo> FileNoInfos { get; set; }
        public virtual DbSet<KhatianDetail> KhatianDetails { get; set; }
        public virtual DbSet<KhatianType> KhatianTypes { get; set; }
        public virtual DbSet<LandDevelopmentTax> LandDevelopmentTaxes { get; set; }
        public virtual DbSet<LandMap> LandMaps { get; set; }
        public virtual DbSet<LandMaster> LandMasters { get; set; }
        public virtual DbSet<LandMasterOwnerRelation> LandMasterOwnerRelations { get; set; }
        public virtual DbSet<LandOwnerType> LandOwnerTypes { get; set; }
        public virtual DbSet<LandOwnersDetail> LandOwnersDetails { get; set; }
        public virtual DbSet<LandSalersInfo> LandSalersInfos { get; set; }
        public virtual DbSet<MapType> MapTypes { get; set; }
        public virtual DbSet<MutationMaster> MutationMasters { get; set; }
        public virtual DbSet<OwnerInfo> OwnerInfos { get; set; }
        public virtual DbSet<OwnerWiseLandSaleDetail> OwnerWiseLandSaleDetails { get; set; }
        public virtual DbSet<OwnerWiseLandTransferDetail> OwnerWiseLandTransferDetails { get; set; }
        public virtual DbSet<OwnerWiseMutationDetail> OwnerWiseMutationDetails { get; set; }
        public virtual DbSet<PlotWiseLandSaleDetail> PlotWiseLandSaleDetails { get; set; }
        public virtual DbSet<PlotWiseLandTransferDetail> PlotWiseLandTransferDetails { get; set; }
        public virtual DbSet<PlotWiseMutationDetail> PlotWiseMutationDetails { get; set; }
        public virtual DbSet<RackNoInfo> RackNoInfos { get; set; }
        public virtual DbSet<SheetNoInfo> SheetNoInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlmirahNoInfo>(entity =>
            {
                entity.ToTable("AlmirahNoInfo");

                entity.Property(e => e.AlmirahNoInfoId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<BayaDeedDetail>(entity =>
            {
                entity.ToTable("BayaDeedDetail");

                entity.Property(e => e.BayaDeedDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BayaDeedDate).HasColumnType("date");

                entity.Property(e => e.BayaDeedNo).HasMaxLength(50);

                entity.Property(e => e.LandMasterId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.BayaDeedDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BayaDeedDetail_LandMaster");
            });

            modelBuilder.Entity<CmnBanglaYear>(entity =>
            {
                entity.HasKey(e => e.BanglaYearId);

                entity.ToTable("CmnBanglaYear");

                entity.Property(e => e.BanglaYearId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BanglaYearName).HasMaxLength(10);
            });

            modelBuilder.Entity<CmnDistrict>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK__CmnDistr__85FDA4C686E9CAA5");

                entity.ToTable("CmnDistrict");

                entity.Property(e => e.DistrictId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DistrictName).HasMaxLength(100);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.CmnDistricts)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CmnDistri__Divis__3C69FB99");
            });

            modelBuilder.Entity<CmnDivision>(entity =>
            {
                entity.HasKey(e => e.DivisionId)
                    .HasName("PK__CmnDivis__20EFC6A8EF39CD2A");

                entity.ToTable("CmnDivision");

                entity.Property(e => e.DivisionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DivisionName).HasMaxLength(100);
            });

            modelBuilder.Entity<CmnDocumentFile>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("CmnDocumentFile");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FileUniqueName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CmnMouza>(entity =>
            {
                entity.HasKey(e => e.MouzaId)
                    .HasName("PK__CmnMouza__F02E00728E917166");

                entity.ToTable("CmnMouza");

                entity.Property(e => e.MouzaId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.MouzaName).HasMaxLength(100);

                entity.HasOne(d => d.Upozila)
                    .WithMany(p => p.CmnMouzas)
                    .HasForeignKey(d => d.UpozilaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CmnMouza__Upozil__44FF419A");
            });

            modelBuilder.Entity<CmnSubRegOffice>(entity =>
            {
                entity.HasKey(e => e.SubRegOfficeId);

                entity.ToTable("CmnSubRegOffice");

                entity.Property(e => e.SubRegOfficeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SubRegOfficeName).HasMaxLength(150);

                entity.HasOne(d => d.Upozila)
                    .WithMany(p => p.CmnSubRegOffices)
                    .HasForeignKey(d => d.UpozilaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CmnSubRegOffice_CmnUpozila");
            });

            modelBuilder.Entity<CmnUpozila>(entity =>
            {
                entity.HasKey(e => e.UpozilaId)
                    .HasName("PK__CmnUpozi__B392254073881B24");

                entity.ToTable("CmnUpozila");

                entity.Property(e => e.UpozilaId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpozilaName).HasMaxLength(100);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.CmnUpozilas)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CmnUpozil__Distr__4222D4EF");
            });

            modelBuilder.Entity<FileCodeInfo>(entity =>
            {
                entity.ToTable("FileCodeInfo");

                entity.Property(e => e.FileCodeInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FileCodeInfoFullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FileCodeInfoName).HasMaxLength(50);
            });

            modelBuilder.Entity<FileLocationDetail>(entity =>
            {
                entity.ToTable("FileLocationDetail");

                entity.Property(e => e.FileLocationDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FileLocationMasterId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.FileLocationMaster)
                    .WithMany(p => p.FileLocationDetails)
                    .HasForeignKey(d => d.FileLocationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileLocationDetail_FileLocationMaster");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.FileLocationDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileLocationDetail_LandMaster");
            });

            modelBuilder.Entity<FileLocationMaster>(entity =>
            {
                entity.ToTable("FileLocationMaster");

                entity.Property(e => e.FileLocationMasterId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AlmirahNoInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedPcIp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.FileCodeInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.RackNoInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.FileNoInfo)
                    .WithMany(p => p.FileLocationMasters)
                    .HasForeignKey(d => d.FileNoInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileLocationMaster_FileNoInfo");

                entity.HasOne(d => d.RackNoInfo)
                    .WithMany(p => p.FileLocationMasters)
                    .HasForeignKey(d => d.RackNoInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileLocationMaster_RackNoInfo");
            });

            modelBuilder.Entity<FileNoInfo>(entity =>
            {
                entity.ToTable("FileNoInfo");

                entity.Property(e => e.FileNoInfoId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.FileCodeInfo)
                    .WithMany(p => p.FileNoInfos)
                    .HasForeignKey(d => d.FileCodeInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileNoInfo_FileCodeInfo");
            });

            modelBuilder.Entity<KhatianDetail>(entity =>
            {
                entity.ToTable("KhatianDetail");

                entity.Property(e => e.KhatianDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.KhatianNo).HasMaxLength(15);

                entity.HasOne(d => d.KhatianType)
                    .WithMany(p => p.KhatianDetails)
                    .HasForeignKey(d => d.KhatianTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KhatianDe__Khati__5CD6CB2B");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.KhatianDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .HasConstraintName("FK_KhatianDetail_LandMaster");

                entity.HasOne(d => d.Mouza)
                    .WithMany(p => p.KhatianDetails)
                    .HasForeignKey(d => d.MouzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KhatianDe__Mouza__5BE2A6F2");
            });

            modelBuilder.Entity<KhatianType>(entity =>
            {
                entity.ToTable("KhatianType");

                entity.Property(e => e.KhatianTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.KhatianTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<LandDevelopmentTax>(entity =>
            {
                entity.ToTable("LandDevelopmentTax");

                entity.Property(e => e.LandDevelopmentTaxId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedPcIp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DakhilaNo).HasMaxLength(100);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.FromDateNavigation)
                    .WithMany(p => p.LandDevelopmentTaxes)
                    .HasForeignKey(d => d.FromDate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandDevelopmentTax_CmnBanglaYear");

                entity.HasOne(d => d.MutationMaster)
                    .WithMany(p => p.LandDevelopmentTaxes)
                    .HasForeignKey(d => d.MutationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandDevelopmentTax_MutationMaster");
            });

            modelBuilder.Entity<LandMap>(entity =>
            {
                entity.ToTable("LandMap");

                entity.Property(e => e.LandMapId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedPcIp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.SheetNoInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.LandMaps)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMap_CmnDistrict");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.LandMaps)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMap_CmnDivision");

                entity.HasOne(d => d.MapType)
                    .WithMany(p => p.LandMaps)
                    .HasForeignKey(d => d.MapTypeId)
                    .HasConstraintName("FK__LandMap__MapType__02B25B50");

                entity.HasOne(d => d.Mouza)
                    .WithMany(p => p.LandMaps)
                    .HasForeignKey(d => d.MouzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMap_CmnMouza");

                entity.HasOne(d => d.SheetNoInfo)
                    .WithMany(p => p.LandMaps)
                    .HasForeignKey(d => d.SheetNoInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMap_SheetNoInfo");

                entity.HasOne(d => d.Upozila)
                    .WithMany(p => p.LandMaps)
                    .HasForeignKey(d => d.UpozilaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMap_CmnUpozila");
            });

            modelBuilder.Entity<LandMaster>(entity =>
            {
                entity.ToTable("LandMaster");

                entity.Property(e => e.LandMasterId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedPcIp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeedNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.IsBayna).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSale).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTransfered).HasDefaultValueSql("((0))");

                entity.Property(e => e.LandDevelopmentAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LandOtherAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LandPurchaseAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LandRegAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalLandAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.LandMasters)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandMaste__Distr__571DF1D5");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.LandMasters)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandMaste__Divis__5629CD9C");

                entity.HasOne(d => d.SubRegOffice)
                    .WithMany(p => p.LandMasters)
                    .HasForeignKey(d => d.SubRegOfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMaster_CmnSubRegOffice");

                entity.HasOne(d => d.Upozila)
                    .WithMany(p => p.LandMasters)
                    .HasForeignKey(d => d.UpozilaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandMaste__Upozi__5812160E");
            });

            modelBuilder.Entity<LandMasterOwnerRelation>(entity =>
            {
                entity.ToTable("LandMasterOwnerRelation");

                entity.Property(e => e.LandMasterOwnerRelationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OtherRemarks).HasMaxLength(50);

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.LandMasterOwnerRelations)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMasterOwnerRelation_LandMaster");

                entity.HasOne(d => d.LandOwnerType)
                    .WithMany(p => p.LandMasterOwnerRelations)
                    .HasForeignKey(d => d.LandOwnerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandMasterOwnerRelation_LandOwnerType1");
            });

            modelBuilder.Entity<LandOwnerType>(entity =>
            {
                entity.ToTable("LandOwnerType");

                entity.Property(e => e.LandOwnerTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LandOwnerTypeName).HasMaxLength(200);
            });

            modelBuilder.Entity<LandOwnersDetail>(entity =>
            {
                entity.ToTable("LandOwnersDetail");

                entity.Property(e => e.LandOwnersDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LandAmount).HasColumnType("decimal(12, 4)");

                entity.Property(e => e.OwnerPurchaseAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OwnerRegAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaleOwnerName).HasMaxLength(100);

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.LandOwnersDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .HasConstraintName("FK_LandOwnersDetail_LandMaster");

                entity.HasOne(d => d.Mouza)
                    .WithMany(p => p.LandOwnersDetails)
                    .HasForeignKey(d => d.MouzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandOwnersDetail_CmnMouza");

                entity.HasOne(d => d.OwnerInfo)
                    .WithMany(p => p.LandOwnersDetails)
                    .HasForeignKey(d => d.OwnerInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandOwnersDetail_OwnerInfo");
            });

            modelBuilder.Entity<LandSalersInfo>(entity =>
            {
                entity.HasKey(e => e.SalersInfoId)
                    .HasName("PK__LandSale__6784BF9AA86C08A1");

                entity.ToTable("LandSalersInfo");

                entity.Property(e => e.SalersInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SalerFatherName).HasMaxLength(100);

                entity.Property(e => e.SalerName).HasMaxLength(100);

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.LandSalersInfos)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandSaler__LandM__693CA210");
            });

            modelBuilder.Entity<MapType>(entity =>
            {
                entity.ToTable("MapType");

                entity.Property(e => e.MapTypeId).ValueGeneratedNever();

                entity.Property(e => e.MapTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MutationMaster>(entity =>
            {
                entity.ToTable("MutationMaster");

                entity.Property(e => e.MutationMasterId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CaseNo).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedPcIp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dcrno)
                    .HasMaxLength(50)
                    .HasColumnName("DCRNo");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.HoldingNo).HasMaxLength(50);

                entity.Property(e => e.IsRecorded).HasDefaultValueSql("((0))");

                entity.Property(e => e.MutationApplicationDate).HasColumnType("date");

                entity.Property(e => e.MutationApplicationNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MutationKhatianNo).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<OwnerInfo>(entity =>
            {
                entity.ToTable("OwnerInfo");

                entity.Property(e => e.OwnerInfoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OwnerInfoName).HasMaxLength(200);
            });

            modelBuilder.Entity<OwnerWiseLandSaleDetail>(entity =>
            {
                entity.ToTable("OwnerWiseLandSaleDetail");

                entity.Property(e => e.OwnerWiseLandSaleDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OwnerWiseSaleLandAmount).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.OwnerWiseLandSaleDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerWiseLandSaleDetail_LandMaster");
            });

            modelBuilder.Entity<OwnerWiseLandTransferDetail>(entity =>
            {
                entity.ToTable("OwnerWiseLandTransferDetail");

                entity.Property(e => e.OwnerWiseLandTransferDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OwnerWiseTransferedLandAmount).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.OwnerWiseLandTransferDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerWiseLandTransferDetail_LandMaster");
            });

            modelBuilder.Entity<OwnerWiseMutationDetail>(entity =>
            {
                entity.ToTable("OwnerWiseMutationDetail");

                entity.Property(e => e.OwnerWiseMutationDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OwnerLandAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.OwnerMutatedLandAmount).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.OwnerWiseMutationDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerWiseMutationDetail_LandMaster");

                entity.HasOne(d => d.MutationMaster)
                    .WithMany(p => p.OwnerWiseMutationDetails)
                    .HasForeignKey(d => d.MutationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerWiseMutationDetail_MutationMaster");

                entity.HasOne(d => d.OwnerInfo)
                    .WithMany(p => p.OwnerWiseMutationDetails)
                    .HasForeignKey(d => d.OwnerInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerWiseMutationDetail_OwnerInfo");
            });

            modelBuilder.Entity<PlotWiseLandSaleDetail>(entity =>
            {
                entity.ToTable("PlotWiseLandSaleDetail");

                entity.Property(e => e.PlotWiseLandSaleDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PlotWiseSaleLandAmount).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.PlotWiseLandSaleDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlotWiseLandSaleDetail_LandMaster");
            });

            modelBuilder.Entity<PlotWiseLandTransferDetail>(entity =>
            {
                entity.ToTable("PlotWiseLandTransferDetail");

                entity.Property(e => e.PlotWiseLandTransferDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PlotWiseTransferedLandAmount).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.PlotWiseLandTransferDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlotWiseLandTransferDetail_LandMaster");
            });

            modelBuilder.Entity<PlotWiseMutationDetail>(entity =>
            {
                entity.ToTable("PlotWiseMutationDetail");

                entity.Property(e => e.PlotWiseMutationDetailId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DagNo).HasMaxLength(50);

                entity.Property(e => e.KhatianNo).HasMaxLength(50);

                entity.Property(e => e.PlotWiseMutationLandAmount).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.LandMaster)
                    .WithMany(p => p.PlotWiseMutationDetails)
                    .HasForeignKey(d => d.LandMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlotWiseMutationDetail_LandMaster");

                entity.HasOne(d => d.MutationMaster)
                    .WithMany(p => p.PlotWiseMutationDetails)
                    .HasForeignKey(d => d.MutationMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlotWiseMutationDetail_MutationMaster");
            });

            modelBuilder.Entity<RackNoInfo>(entity =>
            {
                entity.ToTable("RackNoInfo");

                entity.Property(e => e.RackNoInfoId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.AlmirahNoInfo)
                    .WithMany(p => p.RackNoInfos)
                    .HasForeignKey(d => d.AlmirahNoInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RackNoInfo_AlmirahNoInfo");
            });

            modelBuilder.Entity<SheetNoInfo>(entity =>
            {
                entity.ToTable("SheetNoInfo");

                entity.Property(e => e.SheetNoInfoId).HasDefaultValueSql("(newid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
