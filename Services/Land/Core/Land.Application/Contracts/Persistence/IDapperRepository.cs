using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Land.Application.Contracts.Persistence
{
    public interface IDapperRepository
    {

        T Execute_Sp<T>(string conStrName, string procedureName, string callName, DynamicParameters sp_params);
        List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetList_Sp<T>(string procedureName, string callName, string conStrName, DynamicParameters sp_params);
        GridEntity<T> GetGridData_Sp<T>(GridOptions options, string conStrName, string procedureName, string callName, string orderBy, DynamicParameters sp_params);
    }
}
