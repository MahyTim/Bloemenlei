using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beveiliging
{
    public class Scenario
    {
        public string Naam { get; }

        private readonly List<AlsSensor> _alsSensoren = new List<AlsSensor>();
        private readonly List<DanHueLamp> _danActies = new List<DanHueLamp>();

        public Scenario(string naam)
        {
            Naam = naam;
        }

        public Scenario Als(AanUitSensor sensor, AanUitWaarde waarde)
        {
            _alsSensoren.Add(new AlsSensor()
            {
                Waarde = waarde,
                Sensor = sensor
            });
            return this;
        }

        public Scenario Dan(HueLamp lamp, HueLampHelderheid waarde)
        {
            _danActies.Add(new DanHueLamp()
            {
                Helderheid = waarde,
                Lamp = lamp
            });
            return this;
        }

        public async Task Afspelen(AanUitSensor sensor, AanUitWaarde waarde)
        {
            foreach (var danActie in _danActies)
            {
                await danActie.Lamp.Communiceer(danActie.Helderheid);
            }
        }
        public bool MoetAfspelen(AanUitSensor sensor, AanUitWaarde waarde)
        {
            return _alsSensoren.Any(z => z.Sensor == sensor && z.Waarde == waarde);
        }
    }
}