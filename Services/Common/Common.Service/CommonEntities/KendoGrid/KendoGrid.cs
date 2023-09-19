using System.Linq;

namespace Common.Service.CommonEntities.KendoGrid
{
    public class KendoGrid<T>
    {
        /// <summary>
        /// Kendo UI Grid DataSource
        /// </summary>
        /// <param name="options">kendo grid options</param>
        /// <param name="data">data List</param>
        /// <returns></returns>
        public static GridEntity<T> DataSource(GridOptions options, IQueryable<T> data)
        {
            var data1 = data.ToDataSourceResult(options.take, options.skip, options.sort, options.filter, options.aggregates, options.group);
            return new GridResult<T>().Data(data1, data1.TotalCount);
        }
    }

}
