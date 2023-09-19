using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class LandOwnerTypeRepository : BaseRepository<LandOwnerType>, ILandOwnerTypeRepository
    {
        public LandOwnerTypeRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<GetAllLandOwnerTypeListVm>> GetAllLandOwnerTypeAsync()
        {
            var data = await _dbContext.LandOwnerTypes.AsNoTracking()
                .Select(s=> new GetAllLandOwnerTypeListVm
                {
                    LandOwnerTypeId = s.LandOwnerTypeId,
                    LandOwnerTypeName = s.LandOwnerTypeName,
                    OrderBy = s.OrderBy
                }).OrderBy(o=> o.OrderBy).ToListAsync();
            return data;
        }
        public async Task<List<LandOwnerTypeListByLandMasterIdVm>> GetAllLandOwnerTypeListByLandMasterId(Guid landMasterId)
        {
            var list = await(from lm in _dbContext.LandMasters
                        join lor in _dbContext.LandMasterOwnerRelations on lm.LandMasterId equals lor.LandMasterId into ownerRelation
                        from lor in ownerRelation.DefaultIfEmpty()
                        join lot in _dbContext.LandOwnerTypes on lor.LandOwnerTypeId equals lot.LandOwnerTypeId into owner
                        from lot in owner.DefaultIfEmpty()
                        where (lm.LandMasterId == landMasterId)
                        select new LandOwnerTypeListByLandMasterIdVm
                        {
                            LandMasterId = lor.LandMasterId,
                            LandOwnerTypeId=lor.LandOwnerTypeId,
                            LandOwnerTypeName=lot.LandOwnerTypeName,
                            OtherRemarks = lor.OtherRemarks,
                            LandMasterOwnerRelationId = lor.LandMasterOwnerRelationId
                        }).ToListAsync();
            return list;
        }
    }
}
