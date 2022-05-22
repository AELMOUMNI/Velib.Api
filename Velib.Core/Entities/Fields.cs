using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Velib.Core.Entities
{
    [DataContract]
    public class Fields
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "stationcode")]
        public string Stationcode { get; set; }

        [DataMember(Name = "ebike")]
        public int Ebike { get; set; }

        [DataMember(Name = "mechanical")]
        public int Mechanical { get; set; }

        [DataMember(Name = "coordonnees_geo")]
        public List<double> CoordonneesGeo { get; set; }

        [DataMember(Name = "duedate")]
        public DateTime DueDate { get; set; }

        [DataMember(Name = "numbikesavailable")]
        public int Numbikesavailable { get; set; }

        [DataMember(Name = "numdocksavailable")]
        public int Numdocksavailable { get; set; }

        [DataMember(Name = "capacity")]
        public int Capacity { get; set; }

        [DataMember(Name = "is_renting")]
        public string IsRenting { get; set; }

        [DataMember(Name = "is_installed")]
        public string IsInstalled { get; set; }

        [DataMember(Name = "nom_arrondissement_communes")]
        public string NomArrondissementCommunes { get; set; }

        [DataMember(Name = "is_returning")]
        public string IsReturning { get; set; }

    }
}
