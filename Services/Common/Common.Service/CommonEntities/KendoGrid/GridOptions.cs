using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.CommonEntities.KendoGrid
{
    public class GridOptions
    {
        public int skip { get; set; }
        public int take { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public List<Sort> sort { get; set; }
        public Filter filter { get; set; }

        public IEnumerable<Aggregator> aggregates { get; set; }
        public IEnumerable<Group> group { get; set; }

        //public List<GridSort> sort { get; set; }
        //public GridFilters filter { get; set; }
    }
    public class GridSort
    {
        public string field { get; set; }
        public string dir { get; set; }
    }

    public class GridFilters
    {
        public List<GridFilter> Filters { get; set; }
        public string Logic { get; set; }
    }

    public class GridFilter
    {
        public string Operator { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }

    public class GridEntity<T>
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable Groups { get; set; }
        public object Aggregates { get; set; }
    }

    public class GridResult<T>
    {
        public GridEntity<T> Data1(List<T> list, int totalCount)
        {
            var dEntity = new GridEntity<T>();
            dEntity.Items = list ?? new List<T>();
            dEntity.TotalCount = totalCount;
            return dEntity;
        }

        public GridEntity<T> Data(DataSourceResult data, int totalCount)
        {
            var dEntity = new GridEntity<T>();
            dEntity.Items = (List<T>)data.Items ?? new List<T>();
            dEntity.TotalCount = totalCount;
            dEntity.Aggregates = data.Aggregates;
            dEntity.Groups = data.Groups;
            return dEntity;
        }

    }
}
