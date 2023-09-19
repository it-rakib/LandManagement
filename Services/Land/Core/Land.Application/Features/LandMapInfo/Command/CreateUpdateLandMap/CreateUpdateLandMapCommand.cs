using Land.Application.Features.CmnDocument;
using Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap
{
    public class CreateUpdateLandMapCommand : IRequest<CreateUpdateLandMapCommandResponse>
    {
        public Guid LandMapId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpozilaId { get; set; }
        public Guid MouzaId { get; set; }
        public int? MapTypeId { get; set; }
        public Guid SheetNoInfoId { get; set; }
        public string Remarks { get; set; }
        public string FileRemarks { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedPcIp { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }        
        public virtual ICollection<DocumentVM> DocumentVms { get; set; }
    }
}
