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
    }
}