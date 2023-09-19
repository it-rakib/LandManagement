using MediatR;
using System;

namespace Land.Application.Features.CmnDistrictInfo.Commands.CreateUpdateCmnDistrict
{
    public class CreateCmnDistrictCommand : IRequest<CreateCmnDistrictCommandResponse>
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
    }
}
