using Microsoft.Extensions.Configuration;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;


        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("landConnectionString"));
            return db.Query<T>(query, sp_params, commandType: commandType).ToList();
        }
        public T Execute_Sp<T>(string conStrName, string procedureName, string callName, DynamicParameters sp_params)
        {
            T result;
            using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(conStrName)))
            {
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }

                using var transaction = dbConnection.BeginTransaction();
                try
                {
                    sp_params.Add("@callname", callName);

                    var rv = dbConnection.QuerySingle<T>(procedureName, sp_params, commandType: CommandType.StoredProcedure, transaction: transaction);

                    // var aa = sp_params.Get<int>("Id");
                    result = rv; //get output parameter value

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            };
            return result;
        }
        public List<T> GetList_Sp<T>(string procedureName, string callName, string conStrName, DynamicParameters sp_params)
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(conStrName));
            sp_params.Add("@callname", callName);
            return db.Query<T>(procedureName, sp_params, commandType: CommandType.StoredProcedure).ToList();
        }
        public GridEntity<T> GetGridData_Sp<T>(GridOptions options, string conStrName, string procedureName, string callName, string orderBy, DynamicParameters sp_params)
        {

            options.take = options.skip + options.take;
            var filterby = "";
            if (options.filter != null)
            {
                filterby = options != null ? GridQueryBuilder<T>.FilterCondition(options.filter) : "";
            }

            sp_params.Add("@callname", callName);
            sp_params.Add("@skip", options.skip);
            sp_params.Add("@take", options.take);
            sp_params.Add("@filter", filterby);
            sp_params.Add("@orderby", orderBy);

            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(conStrName));
            var result = db.QueryMultiple(procedureName, sp_params, commandType: CommandType.StoredProcedure);
            int totalCount = result.Read<int>().Count();
            var list = result.Read<T>().ToList();
            return new GridResult<T>().Data1(list, totalCount);
        }
    }
}
