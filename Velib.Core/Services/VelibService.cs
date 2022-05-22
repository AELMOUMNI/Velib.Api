using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velib.Core.Entities;

namespace Velib.Core.Services
{
    public class VelibService : IVelibService
    {
        private readonly HttpClient _httpClient;
        private readonly string _searchEndPoint;
        private readonly string _dataSetKeyEndPoint;
        private readonly string _dataSetValueEndPoint;
        public VelibService(HttpClient httpClient,string searchEndPoint, string dataSetKeyEndPoint, string dataSetValueEndPoint)
        {
            _httpClient = httpClient;
            _searchEndPoint = searchEndPoint;
            _dataSetKeyEndPoint = dataSetKeyEndPoint;
            _dataSetValueEndPoint = dataSetValueEndPoint;
        }

        public async Task<VelibResponse<List<VelibAvailableReelTime>>> GetAllVelibDisponibiliteEnTempsReel(int? total)
        {
            VelibResponse<List<VelibAvailableReelTime>> response;
            var parameters = GetApiKeyValue();
            if (total.HasValue)
                parameters.Add("rows", total.Value.ToString());
 
            response = await GetAsync<VelibResponse<List<VelibAvailableReelTime>>>(_searchEndPoint, parameters);

            return response;
        }

        public async Task<VelibResponse<List<VelibAvailableReelTime>>> GetVelibs()
        {
            VelibResponse<List<VelibAvailableReelTime>> response;
            response = await GetAsync<VelibResponse<List<VelibAvailableReelTime>>>(_searchEndPoint, GetApiKeyValue());

            return response;
        }
        private async Task<T> GetAsync<T>(string url, Dictionary<string, string> parameters)
        {
            T response;
            var baseUrl = new Uri(_httpClient.BaseAddress, url);
            var uriBuilder = new UriBuilder(baseUrl);

            var request = RequestUriUtil.GetUriWithQueryString(uriBuilder.Uri.ToString(), parameters);

            var responseClient = await _httpClient.GetAsync(request).ConfigureAwait(false);
            responseClient.EnsureSuccessStatusCode();
            var stream = await responseClient.Content.ReadAsStreamAsync();

            response = DeserializeJsonFromStream<T>(stream);
            return response;
        }
        private T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);
            using(var streamReader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var jsonSerialiser = new JsonSerializer();
                var srearchResult = jsonSerialiser.Deserialize<T>(jsonTextReader);

                return srearchResult;
            }
        }
        private Dictionary<string, string> GetApiKeyValue()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {_dataSetKeyEndPoint, _dataSetValueEndPoint }
            };
            return parameters;
        }

        public class RequestUriUtil
        {
            public static string GetUriWithQueryString(string requestUri,
                Dictionary<string, string> queryStringParams)
            {
                bool startingQuestionMarkAdded = false;
                var sb = new StringBuilder();
                sb.Append(requestUri);
                foreach (var parameter in queryStringParams)
                {
                    if (parameter.Value == null)
                    {
                        continue;
                    }

                    sb.Append(startingQuestionMarkAdded ? '&' : '?');
                    sb.Append(parameter.Key);
                    sb.Append('=');
                    sb.Append(parameter.Value);
                    startingQuestionMarkAdded = true;
                }
                return sb.ToString();
            }
        }
    }
}
