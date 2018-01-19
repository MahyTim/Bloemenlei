using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Beveiliging
{
    public class HueLampCommunicatieViaHttp : IHueLampCommunicatie
    {
        private readonly HueLampCommunicatieViaHttpOpties _opties;
        private readonly int _nummer;

        public HueLampCommunicatieViaHttp(HueLampCommunicatieViaHttpOpties opties, int nummer)
        {
            _opties = opties;
            _nummer = nummer;
        }

        public async Task<Helderheid> Lees()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetStringAsync($"{_opties.Url}/api/{_opties.Gebruiker}/lights/{_nummer}");
            var jsonResponse = JToken.Parse(response);
            var on = bool.Parse(jsonResponse["state"]["on"].Value<string>());
            return on == false ? Helderheid.Minimum : new Helderheid(uint.Parse(jsonResponse["state"]["bri"].Value<string>()));
        }

        public async Task Zet(Helderheid waarde)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = waarde.Equals(Helderheid.Minimum) ? JToken.FromObject(new { on = false }) : JToken.FromObject(new
            {
                on = true,
                bri = waarde.Waarde
            });

            var message = new HttpRequestMessage(HttpMethod.Put,
                $"{_opties.Url}/api/{_opties.Gebruiker}/lights/{_nummer}/state")
            {
                Content = new StringContent(json.ToString())
            };
            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode == false)
                throw new HueLampCommunicatieViaHttpException();
        }
    }
}