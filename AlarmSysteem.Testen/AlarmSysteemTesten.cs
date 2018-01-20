using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;

namespace Beveiliging.Testen
{
    public class AlarmSysteemTesten
    {
        public class DummyAlarmSysteem : AlarmSysteem
        {
            public HueLamp BureauLamp;
            public AanUitSensor BureauSensor;

            public DummyAlarmSysteem()
            {
                BureauLamp = HueLamp("bureaulamp", new FakeHueLampCommunicatie());
                BureauSensor = BewegingSensor("bureausensor", new FakeAanUitSensorCommunicatie());

                Scenario("LampAanBijBeweging")
                    .Als(BureauSensor, AanUitWaarde.Aan)
                    .Dan(BureauLamp, HueLampHelderheid.Maximum);
            }
        }

        [Fact]
        public async Task Test_Lamp_Gaat_Aan_Bij_Beweging()
        {
            var onderwerp = new DummyAlarmSysteem();
            var afgespeeldeScenarios = await onderwerp.Ontvang(onderwerp.BureauSensor, AanUitWaarde.Aan);

            Assert.Single(afgespeeldeScenarios);
            Assert.Equal("Lamp 'bureaulamp' is 'aan'", onderwerp.BureauLamp.ToString());
        }

        [Fact]
        public async Task Test_Lamp_Gaat_Niet_Aan_Bij_Geen_Beweging()
        {
            var onderwerp = new DummyAlarmSysteem();
            var afgespeeldeScenarios = await onderwerp.Ontvang(onderwerp.BureauSensor, AanUitWaarde.Uit);
            Assert.Empty(afgespeeldeScenarios);
        }
    }
}