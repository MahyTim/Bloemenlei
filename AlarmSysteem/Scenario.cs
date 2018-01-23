using System.Linq;
using System.Threading.Tasks;

namespace Beveiliging
{
    public abstract class Scenario
    {
        public string Omschrijving { get; }

        public Scenario(string omschrijving)
        {
            Omschrijving = omschrijving;
        }

        public abstract Task Afspelen(AanUitSensor sensor, AanUitWaarde waarde);
        public abstract bool MoetAfspelen(AanUitSensor sensor, AanUitWaarde waarde);
    }
}