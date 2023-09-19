using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandInfoGlobalSearch
{
    public class GetLandInfoGlobalSearchVm
    {
        public Guid LandMasterId { get; set; }
        public Guid FileNoInfoId { get; set; }
        public int FileNoInfoName { get; set; }
        public Guid LandOwnerTypeId { get; set; }
        public string LandOwnerTypeName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public string DeedNo { get; set; }
        public string EntryDate { get; set; }        
        public decimal? TotalLandAmount { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianTypeName { get; set; }
        public string KhatianNo { get; set; }
        public string DagNo { get; set; }
        public string HoldingNo { get; set; }
        public Guid BanglaYearId { get; set; }
        public string BanglaYearName { get; set; }
    }
}
