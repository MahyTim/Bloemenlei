using Beveiliging.Communicatie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beveiliging.Testen
{
    public class FakeHueLampCommunicatie : IHueLampCommunicatie
    {
        private Dictionary<HueLamp, HueLampHelderheid> _lampen = new Dictionary<HueLamp, HueLampHelderheid>();

        public Task<HueLampHelderheid> Lees(HueLamp lamp)
        {
            return Task.FromResult(_lampen.ContainsKey(lamp) ? _lampen[lamp] : HueLampHelderheid.Minimum);
        }



        public Task Zet(HueLamp lamp, HueLampHelderheid waarde)
        {
            _lampen[lamp] = waarde;
            return Task.FromResult((object)null);
        }
    }
}