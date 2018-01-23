using System.Threading.Tasks;

namespace Beveiliging
{

    public class HueLamp
    {
        public string Omschrijving { get; }
        public HueLampNummer Nummer { get; }

        public HueLamp(string omschrijving, HueLampNummer nummer)
        {
            Omschrijving = omschrijving;
            Nummer = nummer;
        }
    }
}