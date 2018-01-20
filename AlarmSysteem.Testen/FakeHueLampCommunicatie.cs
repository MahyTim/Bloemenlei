using System.Threading.Tasks;

namespace Beveiliging.Testen
{
    public class FakeHueLampCommunicatie : IHueLampCommunicatie
    {
        private HueLampHelderheid _current;
        public Task<HueLampHelderheid> Lees()
        {
            return Task.FromResult(_current);
        }

        public async Task Zet(HueLampHelderheid waarde)
        {
            _current = waarde;
        }
    }
}