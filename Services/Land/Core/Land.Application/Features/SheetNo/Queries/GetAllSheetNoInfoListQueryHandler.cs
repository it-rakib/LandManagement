using AutoMapper;
using Common.Service.Repositories;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictList;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.SheetNo.Queries
{
    public class GetAllSheetNoInfoListQueryHandler : IRequestHandler<GetAllSheetNoInfoListQuery, List<GetAllSheetNoInfoListVm>>
    {
        private readonly IAsyncRepository<SheetNoInfo> _sheetNoInfoRepository;
        private readonly IMapper _mapper;

        public GetAllSheetNoInfoListQueryHandler(IAsyncRepository<SheetNoInfo> sheetNoInfoRepository, IMapper mapper)
        {
            _sheetNoInfoRepository = sheetNoInfoRepository ?? throw new ArgumentNullException(nameof(sheetNoInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllSheetNoInfoListVm>> Handle(GetAllSheetNoInfoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = (await _sheetNoInfoRepository.GetAllAsync()).OrderBy(o=> o.SheetNo);
                return _mapper.Map<List<GetAllSheetNoInfoListVm>>(list);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
