using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmartSolutions.Mobile.Api
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;


        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, bool aquireToken = false)
        {
            HttpResponseMessage response = null;
            try
            {
                HttpClient httpClient = await CreateHttpClient(aquireToken);
                response = await httpClient.GetAsync(uri);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, bool aquireToken = false)
        {
            TResult result = default(TResult);
            HttpClient httpClient = await CreateHttpClient(aquireToken);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            //Add Validation For valid Json
            var IsStringJson = IsValidJson(serialized);
            if (IsStringJson)
            {
                result = await Task.Run(() =>
                   JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));
            }
            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, string data, bool aquireToken = false)
        {
            HttpClient httpClient = await CreateHttpClient(aquireToken);
            TResult result = default(TResult);
            var content = new StringContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            //Add Validation For valid Json
            var IsStringJson = IsValidJson(serialized);
            if (IsStringJson)
            {
                result = await Task.Run(() =>
                   JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));
            }
            return result;
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, bool aquireToken = false)
        {
            HttpClient httpClient = await CreateHttpClient(aquireToken);
            TResult result = default(TResult);
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            //Add Validation For valid Json
            var IsStringJson = IsValidJson(serialized);
            if (IsStringJson)
            {
                result = await Task.Run(() =>
               JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));
            }
            return result;
        }

        public async Task DeleteAsync(string uri, string token = "")
        {
            HttpClient httpClient = await CreateHttpClient();
            await httpClient.DeleteAsync(uri);
        }

        private async Task<HttpClient> CreateHttpClient(bool aquireToken = false)
        {
            string uri = "https://192.168.0.218:7239";
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            //if (!aquireToken && !string.IsNullOrEmpty(AppSettings.CurrentUser?.Token))
            //{
            //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppSettings.CurrentUser?.Token);
            //}
            //else
            //{
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
            //}

            return httpClient;
        }



        private void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (httpClient == null)
                return;

            if (string.IsNullOrEmpty(parameter))
                return;

            httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }



        //private async Task HandleResponse(HttpResponseMessage response)
        //{
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();

        //        if (response.StatusCode == HttpStatusCode.Forbidden ||
        //            response.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new ServiceAuthenticationException(content);
        //        }

        //        throw new HttpRequestExceptionEx(response.StatusCode, content);
        //    }
        //}

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (response?.IsSuccessStatusCode == true)
            {

            }
            else
            {

                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //throw new ServiceAuthenticationException(content);
                    var ex = new ServiceAuthenticationException(content);
                }

                //throw new HttpRequestExceptionEx(response.StatusCode, content);
                var exception = new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }

        #region [Private Helpers]
        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
