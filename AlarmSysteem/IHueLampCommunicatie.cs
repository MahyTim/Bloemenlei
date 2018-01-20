using System.Threading.Tasks;

namespace Beveiliging
{
    public interface IHueLampCommunicatie
    {
        Task<HueLampHelderheid> Lees();
        Task Zet(HueLampHelderheid waarde);
    }
}