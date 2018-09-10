using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuizQuick
{
    public class RestService : IRestService
    {
        HttpClient client;
        public JsonLogin Items { get; set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<JsonLogin> RefreshDataAsync(string usuario, string contrasena)
        {
            Items = new JsonLogin();

            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty)) + "/api/login";

            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("usu_nombre", usuario);
                pairs.Add("usu_contrasenia", contrasena);

                var json = JsonConvert.SerializeObject(pairs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                var response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<JsonLogin>(data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
