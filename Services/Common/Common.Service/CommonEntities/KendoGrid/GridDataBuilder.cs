
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Service.CommonEntities.KendoGrid
{
    public static class GridQueryBuilder<T>
    {
        #region for Grid
        public static string Query(GridOptions options, string query, string orderBy, string gridCondition)
        {
            string condition = "";
            if (options != null)
            {
                condition = FilterCondition(options.filter);
            }
            if (!string.IsNullOrEmpty(condition))
            {
                condition = " WHERE " + condition;
            }
            if (!string.IsNullOrEmpty(gridCondition))
            {
                if (string.IsNullOrEmpty(condition))
                {
                    condition = " WHERE " + gridCondition;
                }
                else
                {
                    condition += " AND " + gridCondition;
                }
            }

            string orderby = "";
            if (options != null)
            {
                if (options.sort != null)
                {
                    foreach (var gridSort in options.sort)
                    {
                        if (orderby == "")
                        {
                            orderby += "ORDER by " + gridSort.Field + " " + gridSort.Dir;
                        }
                        else
                        {
                            orderby += " , " + gridSort.Field + " " + gridSort.Dir;
                        }
                    }
                }
            }

            if (orderby == "")
            {
                if (!String.IsNullOrEmpty(orderBy))
                {
                    orderby = " ORDER BY " + orderBy;
                }
                else
                {
                    throw new Exception("Must be set Orderby column Name");
                }
            }
            int pageupperBound = 0;
            int skip = 0;
            if (options != null)
            {
                skip = options.skip;
                pageupperBound = skip + options.take;
            }
            var sql = "";
            if (options.pageSize == 0)
            {
                sql = query;
            }
            else
            {
                sql =
               string.Format(
                   @"SELECT * FROM (SELECT ROW_NUMBER() OVER({4}) AS ROWINDEX, T.* FROM ({0}) T {2}) tbl WHERE ROWINDEX >{1} AND ROWINDEX <={3}",
                   query, skip, condition, pageupperBound, orderby);
            }
            return sql;
        }

        public static string FilterCondition(Filter filter)
        {
            string whereClause = "";

            var fltrs = filter.Filters.ToList();

            if (filter != null && (filter.Filters != null && fltrs.Count() > 0))
            {

                var parameters = new List<object>();
                //var filters = filter.Filters;

                for (var i = 0; i < fltrs.Count(); i++)
                {
                    if (i == 0)
                    {
                        if (fltrs[i].Value == null)
                        {
                            i = i + 1;
                            if (fltrs.Count == i)
                            {
                                break;
                            }
                        }
                        whereClause += string.Format(" {0}",
                                                     UtilityCommon.BuildWhereClause<T>(i, filter.Logic,
                                                                                       fltrs[i],
                                                                                       parameters));
                    }
                    else
                    {
                        if (fltrs[i].Value != null)
                        {
                            whereClause += string.Format(" {0} {1}",
                                                         UtilityCommon.ToLinqOperator(filter.Logic),
                                                         UtilityCommon.BuildWhereClause<T>(i, filter.Logic,
                                                                                           fltrs[i],
                                                                                           parameters));
                        }
                    }
                }
            }
            return whereClause;
        }

        #endregion


    }


}
