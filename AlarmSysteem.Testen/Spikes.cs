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
            var onderwerp = new HueLampCommunicatieViaHttp(opties, 1);

            await onderwerp.Zet(Helderheid.Maximum);
            Thread.Sleep(2000);
            Assert.Equal(Helderheid.Maximum, await onderwerp.Lees());
            Thread.Sleep(2000);
            await onderwerp.Zet(Helderheid.Minimum);
            Thread.Sleep(2000);
            Assert.Equal(Helderheid.Minimum, await onderwerp.Lees());
            Thread.Sleep(2000);
            await onderwerp.Zet(Helderheid.Maximum);

            Thread.Sleep(2000);
            await onderwerp.Zet(new Helderheid(50));

        }
    }
}