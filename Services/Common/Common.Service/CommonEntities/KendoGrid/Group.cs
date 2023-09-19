using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Service.CommonEntities.KendoGrid
{
    public class Group : Sort
    {
        [DataMember(Name = "aggregates")]
        public IEnumerable<Aggregator> Aggregates { get; set; }
    }
}
