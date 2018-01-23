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

            public DummyAlarmSysteem(FakeHueLampCommunicatie communicatie) : base(communicatie, new FakeAanUitSensorCommunicatie())
            {
                BureauLamp = HueLamp("bureaulamp", new HueLampNummer(1));
                BureauSensor = BewegingSensor("bureausensor");

                Scenario("LampAanBijBeweging")
                    .AlsDan()
                        .Als(BureauSensor, AanUitWaarde.Aan)
                        .Dan(BureauLamp, HueLampHelderheid.Maximum);
            }
        }

        [Fact]
        public async Task Test_Lamp_Gaat_Aan_Bij_Beweging()
        {
            var communicatie = new FakeHueLampCommunicatie();
            var onderwerp = new DummyAlarmSysteem(communicatie);
            var afgespeeldeScenarios = await onderwerp.Ontvang(onderwerp.BureauSensor, AanUitWaarde.Aan);

            Assert.Single(afgespeeldeScenarios);

            Assert.Equal(HueLampHelderheid.Maximum, (await communicatie.Lees(onderwerp.BureauLamp)));
        }

        [Fact]
        public async Task Test_Lamp_Gaat_Niet_Aan_Bij_Geen_Beweging()
        {
            var onderwerp = new DummyAlarmSysteem(new FakeHueLampCommunicatie());
            var afgespeeldeScenarios = await onderwerp.Ontvang(onderwerp.BureauSensor, AanUitWaarde.Uit);
            Assert.Empty(afgespeeldeScenarios);
        }
    }
}