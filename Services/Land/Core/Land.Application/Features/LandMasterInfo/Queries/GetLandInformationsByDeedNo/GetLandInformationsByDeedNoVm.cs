using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandInformationsByDeedNo
{
    public class GetLandInformationsByDeedNoVm
    {
        public Guid LandMasterId { get; set; }
        //public string FileNo { get; set; }
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
        public DateTime? EntryDate { get; set; }
        public string DeedNo { get; set; }
        public decimal? LandAmount { get; set; }
        public string KhatianNo { get; set; }
        public string DagNo { get; set; }
        public string RecordedOwnerName { get; set; }
    }
}
