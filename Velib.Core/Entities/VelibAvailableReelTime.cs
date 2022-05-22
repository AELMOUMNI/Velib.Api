using System;
using System.Runtime.Serialization;

namespace Velib.Core.Entities
{
    [DataContract(Name = "records")]
    public class VelibAvailableReelTime
    {
        [DataMember(Name = "datasetid")]
        public string DataSetId { get; set; }

        [DataMember(Name = "recordid")]
        public string RecordId { get; set; }

        [DataMember(Name = "fields")]
        public Fields Fields { get; set; }

        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }

        [DataMember(Name = "record_timestamp")]
        public DateTime RecordTimestamp { get; set; }
    }
}
