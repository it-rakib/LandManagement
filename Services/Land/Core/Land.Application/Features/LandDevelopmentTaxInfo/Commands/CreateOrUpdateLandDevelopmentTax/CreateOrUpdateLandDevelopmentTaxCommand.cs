using System;
using System.Collections.Generic;
using Land.Application.Features.CmnDocument;
using MediatR;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax
{
    public class CreateOrUpdateLandDevelopmentTaxCommand : IRequest<CreateOrUpdateLandDevelopmentTaxCommandResponse>
    {
        public Guid LandDevelopmentTaxId { get; set; }
        public Guid MutationMasterId { get; set; }
        public string DakhilaNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid FromDate { get; set; }
        public Guid ToDate { get; set; }
        public decimal? TaxAmount { get; set; }
        public string Remarks { get; set; }
        public string FileRemarks { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedPcIp { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<DocumentVM> DocumentVms { get; set; }
    }
}
