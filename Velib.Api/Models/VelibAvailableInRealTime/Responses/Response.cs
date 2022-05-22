using System.Text.Json.Serialization;

namespace Velib.Api.Models
{
    /// <summary>
    /// La reponse
    /// </summary>
    /// <typeparam name="T">Les enregistrements</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Le nomdre des enregistrements
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Count { get; set; }

        /// <summary>
        /// La liste des enregistrements
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; set; }

        /// <summary>
        /// Le statut de la reponse
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Status { get; set; }
    }
}
