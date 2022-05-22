using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Velib.Api.Models
{
    [DataContract]
    public class Parameters
    {
        public string DataSet { get; set; }

        public string Rows { get; set; }

        public int Start { get; set; }

        public string Format { get; set; }

        public string Timezone { get; set; }
    }
}
