using System.Threading.Tasks;

namespace Beveiliging.Testen
{
    public class FakeHueLampCommunicatie : IHueLampCommunicatie
    {
        private Helderheid _current;
        public Task<Helderheid> Lees()
        {
            return Task.FromResult(_current);
        }

        public async Task Zet(Helderheid waarde)
        {
            _current = waarde;
        }
    }
}