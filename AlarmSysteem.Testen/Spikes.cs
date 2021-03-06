using Beveiliging.Communicatie;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace Beveiliging.Testen
{
    public class Spikes
    {
        [Fact]
        public async Task Spike_HueLampCommunicatieViaHttp()
        {
            var opties = new HueLampCommunicatieViaHttpOpties()
            {
                Gebruiker = "FSThaAfM4jmrz0xaPoTu1mkwrwP4db5HZMRwAIWq",
                Url = "http://192.168.0.142"
            };
            var onderwerp = new HueLampCommunicatieViaHttp(opties);

            var lamp = new HueLamp("Buro", new HueLampNummer(1));

            await onderwerp.Zet(lamp, HueLampHelderheid.Maximum);
            Thread.Sleep(5000);
            Assert.Equal(HueLampHelderheid.Maximum, await onderwerp.Lees(lamp));
            Thread.Sleep(5000);
            await onderwerp.Zet(lamp, HueLampHelderheid.Minimum);
            Thread.Sleep(5000);
            Assert.Equal(HueLampHelderheid.Minimum, await onderwerp.Lees(lamp));
            Thread.Sleep(5000);
            await onderwerp.Zet(lamp, HueLampHelderheid.Maximum);
            Thread.Sleep(5000);
            await onderwerp.Zet(lamp, new HueLampHelderheid(50));
        }
    }
}
