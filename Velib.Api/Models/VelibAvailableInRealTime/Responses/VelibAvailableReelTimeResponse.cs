using System;
using System.Collections.Generic;

namespace Velib.Api.Models
{
    /// <summary>
    /// Vélos disponibile temps réel
    /// </summary>
    public class VelibAvailableReelTimeResponse
    {
        /// <summary>
        /// Nom station
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Identifiant de station
        /// </summary>
        public int StationCode { get; set; }
        /// <summary>
        /// Vélos électriques disponibles
        /// </summary>
        public int Ebike { get; set; }
        /// <summary>
        /// Vélos mécaniques disponibles
        /// </summary>
        public int Mechanical { get; set; }
        /// <summary>
        /// Coordonées géographiques 
        /// </summary>
        public List<double> CoordonneesGeo { get; set; }
        /// <summary>
        /// Actualisation de la donnée
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// Nombre total vélos disponible
        /// </summary>
        public int Numbikesavailable { get; set; }
        /// <summary>
        /// Nombre bornettes libres
        /// </summary>
        public int Numdocksavailable { get; set; }
        /// <summary>
        /// Capacité de la station
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// Station en fonctionnement
        /// </summary>
        public string IsRenting { get; set; }
        /// <summary>
        /// Borne de paiement disponible
        /// </summary>
        public string IsInstalled { get; set; }
        /// <summary>
        /// Nom communes équipées
        /// </summary>
        public string NomArrondissementCommunes { get; set; }
        /// <summary>
        /// Retour vélib possible
        /// </summary>
        public string IsReturning { get; set; }
    }
}
