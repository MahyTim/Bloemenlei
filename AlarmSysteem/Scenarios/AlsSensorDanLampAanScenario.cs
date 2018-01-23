using Beveiliging.Communicatie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beveiliging.Scenarios
{
    public class ScenarioBouwer
    {
        private readonly IHueLampCommunicatie _hueLampCommunicatie;
        private readonly Func<Scenario,Scenario> _onCreated;
        private readonly string _omschrijving;

        public ScenarioBouwer(string omschrijving, IHueLampCommunicatie hueLampCommunicatie,Func<Scenario,Scenario> onCreated)
        {
            _hueLampCommunicatie = hueLampCommunicatie;
            _onCreated = onCreated;
            _omschrijving = omschrijving;
        }

        public AlsSensorDanLampAanScenario AlsDan()
        {
            return _onCreated( new AlsSensorDanLampAanScenario(_omschrijving, _hueLampCommunicatie)) as AlsSensorDanLampAanScenario;
        }
    }

    public class AlsSensorDanLampAanScenario : Scenario
    {
        public IHueLampCommunicatie LampCommunicatie { get; }

        private readonly List<AlsSensor> _alsSensoren = new List<AlsSensor>();
        private readonly List<DanHueLamp> _danActies = new List<DanHueLamp>();

        public AlsSensorDanLampAanScenario(string omschrijving, IHueLampCommunicatie lampCommunicatie) : base(omschrijving)
        {
            LampCommunicatie = lampCommunicatie;
        }

        public AlsSensorDanLampAanScenario Als(AanUitSensor sensor, AanUitWaarde waarde)
        {
            _alsSensoren.Add(new AlsSensor()
            {
                Waarde = waarde,
                Sensor = sensor
            });
            return this;
        }

        public AlsSensorDanLampAanScenario Dan(HueLamp lamp, HueLampHelderheid waarde)
        {
            _danActies.Add(new DanHueLamp()
            {
                Helderheid = waarde,
                Lamp = lamp
            });
            return this;
        }

        public override async Task Afspelen(AanUitSensor sensor, AanUitWaarde waarde)
        {
            foreach (var danActie in _danActies)
            {
                await LampCommunicatie.Zet(danActie.Lamp, danActie.Helderheid);
            }
        }
        public override bool MoetAfspelen(AanUitSensor sensor, AanUitWaarde waarde)
        {
            return _alsSensoren.Any(z => z.Sensor == sensor && z.Waarde == waarde);
        }
    }
}