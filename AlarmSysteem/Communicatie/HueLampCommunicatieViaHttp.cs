using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Beveiliging.Communicatie
{
    public class HueLampCommunicatieViaHttp : IHueLampCommunicatie
    {
        private readonly HueLampCommunicatieViaHttpOpties _opties;

        public HueLampCommunicatieViaHttp(HueLampCommunicatieViaHttpOpties opties)
        {
            _opties = opties;
        }

        public async Task<HueLampHelderheid> Lees(HueLamp lamp)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStringAsync($"{_opties.Url}/api/{_opties.Gebruiker}/lights/{lamp.Nummer.Waarde}");
            var jsonResponse = JToken.Parse(response);
            var on = bool.Parse(jsonResponse["state"]["on"].Value<string>());
            return on == false ? HueLampHelderheid.Minimum : new HueLampHelderheid(uint.Parse(jsonResponse["state"]["bri"].Value<string>()));
        }

        public async Task Zet(HueLamp lamp, HueLampHelderheid waarde)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = waarde.Equals(HueLampHelderheid.Minimum) ? JToken.FromObject(new { on = false }) : JToken.FromObject(new
            {
                on = true,
                bri = waarde.Waarde
            });

            var message = new HttpRequestMessage(HttpMethod.Put,
                $"{_opties.Url}/api/{_opties.Gebruiker}/lights/{lamp.Nummer.Waarde}/state")
            {
                Content = new StringContent(json.ToString())
            };
            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode == false)
                throw new HueLampCommunicatieViaHttpException();
        }
    }
}