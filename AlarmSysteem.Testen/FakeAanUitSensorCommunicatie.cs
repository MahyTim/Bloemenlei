using System.Threading.Tasks;

namespace Beveiliging.Testen
{
    public class FakeAanUitSensorCommunicatie : IAanUitSensorCommunicatie
    {
        private AanUitWaarde _waarde;

        public async Task Zet(AanUitWaarde waarde)
        {
            _waarde = waarde;
        }

        public Task<AanUitWaarde> Lees()
        {
            return Task.FromResult(_waarde);
        }
    }
}