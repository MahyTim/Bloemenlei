using Beveiliging.Communicatie;
using Beveiliging.Scenarios;
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
        private readonly IHueLampCommunicatie _lampCommunicatie;
        private readonly IAanUitSensorCommunicatie aanUitSensorCommunicatie;

        public AlarmSysteem(IHueLampCommunicatie lampCommunicatie, IAanUitSensorCommunicatie communicatie)
        {
            this._lampCommunicatie = lampCommunicatie;
        }

        protected AlsSensorDanLampAanScenario Scenario(string omschrijving)
        {
            return _scenarios.OfType<AlsSensorDanLampAanScenario>().FirstOrDefault(z => z.Omschrijving == omschrijving) ??
                   _scenarios.AddAndReturn(new AlsSensorDanLampAanScenario(omschrijving, _lampCommunicatie));
        }

        protected AanUitSensor BewegingSensor(string naam)
        {
            return _aanUitSensoren.FirstOrDefault(z => z.Naam == naam) ??
                   _aanUitSensoren.AddAndReturn(new AanUitSensor(naam));

        }

        protected HueLamp HueLamp(string naam, HueLampNummer nummer)
        {
            return _hueLampen.FirstOrDefault(z => z.Omschrijving == naam) ??
                   _hueLampen.AddAndReturn(new HueLamp(naam, nummer));
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
