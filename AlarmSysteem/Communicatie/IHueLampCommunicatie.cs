using System.Threading.Tasks;

namespace Beveiliging.Communicatie
{
    public interface IHueLampCommunicatie
    {
        Task<HueLampHelderheid> Lees(HueLamp lamp);
        Task Zet(HueLamp lamp, HueLampHelderheid waarde);
    }
}