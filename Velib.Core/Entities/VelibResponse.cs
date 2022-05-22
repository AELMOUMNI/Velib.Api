using System.Runtime.Serialization;

namespace Velib.Core.Entities
{
    [DataContract]
    public class VelibResponse<T>
    {

        [DataMember(Name = "nhits")]
        public int Nhits { get; set; }

        [DataMember(Name = "parameters")]
        public Parameters Parameters { get; set; }

        [DataMember(Name = "records")]
        public T Records { get; set; }
    }
}
