using System.Threading.Tasks;

namespace Beveiliging
{
    public interface IHueLampCommunicatie
    {
        Task<Helderheid> Lees();
        Task Zet(Helderheid waarde);
    }
}