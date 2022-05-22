using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Velib.Core.Entities
{
    [DataContract]
    public class Geometry
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "coordinates")]
        public List<double> Coordinates { get; set; }
    }
}
