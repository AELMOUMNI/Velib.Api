using Newtonsoft.Json;

namespace Velib.Api.Models
{
    public class VelibData<T>
    {
        public int Nhits { get; set; }

        public Parameters Parameters { get; set; }

        public T Records { get; set; }
    }
}
