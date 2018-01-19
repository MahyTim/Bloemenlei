using System.Threading.Tasks;
using Xunit;

namespace Beveiliging.Testen
{
    public class AlarmSysteemTesten
    {
        public class DummyAlarmSysteem : AlarmSysteem
        {
            public DummyAlarmSysteem()
            {
                var bureauLamp = HueLamp("bureaulamp", new FakeHueLampCommunicatie());
                var bureausensor = BewegingSensor("bureausensor", new FakeAanUitSensorCommunicatie());


            }
        }

        [Fact]
        public async Task Test_Lamp_Gaat_Aan_Bij_Beweging()
        {

        }
    }
}