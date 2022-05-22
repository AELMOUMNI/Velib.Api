using System.Runtime.Serialization;

namespace Velib.Core.Entities
{
    [DataContract]
    public class Parameters
    {
        [DataMember(Name = "dataset")]
        public string DataSet { get; set; }

        [DataMember(Name = "rows")]
        public string Rows { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "format")]
        public string Format { get; set; }

        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }
    }
}
