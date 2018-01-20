using System.Threading.Tasks;

namespace Beveiliging
{
    public class HueLamp
    {
        private readonly string _naam;
        private readonly IHueLampCommunicatie _communicatie;
        public string Naam { get; set; }

        public HueLamp(string naam, IHueLampCommunicatie communicatie)
        {
            _naam = naam;
            _communicatie = communicatie;
        }

        public async Task Communiceer(HueLampHelderheid nieuweHelderHeid)
        {
            await _communicatie.Zet(nieuweHelderHeid);
        }

        public override string ToString()
        {
            var status = _communicatie.Lees().Result.Waarde > 0 ? "aan" : "uit";
            return $"Lamp '{_naam}' is '{status}'";
        }
    }
}