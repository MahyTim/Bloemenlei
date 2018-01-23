using Beveiliging.Communicatie;
using System;

namespace Beveiliging.Scenarios
{
    public class ScenarioBouwer
    {
        private readonly IHueLampCommunicatie _hueLampCommunicatie;
        private readonly Func<Scenario, Scenario> _onCreated;
        private readonly string _omschrijving;

        public ScenarioBouwer(string omschrijving, IHueLampCommunicatie hueLampCommunicatie, Func<Scenario, Scenario> onCreated)
        {
            _hueLampCommunicatie = hueLampCommunicatie;
            _onCreated = onCreated;
            _omschrijving = omschrijving;
        }

        public AlsSensorDanLampAanScenario AlsDan()
        {
            return _onCreated(new AlsSensorDanLampAanScenario(_omschrijving, _hueLampCommunicatie)) as AlsSensorDanLampAanScenario;
        }
    }
}