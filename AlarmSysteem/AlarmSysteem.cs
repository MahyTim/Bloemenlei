using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Beveiliging
{
    public class AlarmSysteem
    {
        private readonly List<HueLamp> _hueLampen = new List<HueLamp>();
        private readonly List<AanUitSensor> _aanUitSensoren = new List<AanUitSensor>();
        private readonly List<Scenario> _scenarios = new List<Scenario>();

        protected Scenario Scenario(string naam)
        {
            return _scenarios.FirstOrDefault(z => z.Naam == naam) ??
                   _scenarios.AddAndReturn(new Scenario(naam));
        }

        protected AanUitSensor BewegingSensor(string naam, IAanUitSensorCommunicatie communicatie)
        {
            return _aanUitSensoren.FirstOrDefault(z => z.Naam == naam) ??
                   _aanUitSensoren.AddAndReturn(new AanUitSensor(naam, communicatie));

        }

        protected HueLamp HueLamp(string naam, IHueLampCommunicatie communicatie)
        {
            return _hueLampen.FirstOrDefault(z => z.Naam == naam) ??
                   _hueLampen.AddAndReturn(new HueLamp(naam, communicatie));
        }

        public async Task<Scenario[]> Ontvang(AanUitSensor sensor, AanUitWaarde waarde)
        {
            var afgespeeldeScenarios = new List<Scenario>();

            foreach (var scenario in _scenarios)
            {
                if (scenario.MoetAfspelen(sensor, waarde))
                {
                    await scenario.Afspelen(sensor, waarde);
                    afgespeeldeScenarios.Add(scenario);
                }
            }
            return afgespeeldeScenarios.ToArray();
        }
    }
}
