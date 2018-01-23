using Beveiliging.Communicatie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beveiliging.Testen
{
    public class FakeAanUitSensorCommunicatie : IAanUitSensorCommunicatie
    {
        private Dictionary<AanUitSensor, AanUitWaarde> _waarden = new Dictionary<AanUitSensor, AanUitWaarde>();


        public Task<AanUitWaarde> Lees(AanUitSensor sensor)
        {
            if(_waarden.ContainsKey(sensor))
            {
                return Task.FromResult(_waarden[sensor]);
            }
            return Task.FromResult(AanUitWaarde.Uit);
        }

        public async Task Zet(AanUitSensor sensor, AanUitWaarde waarde)
        {
            _waarden[sensor] = waarde;
        }
    }
}