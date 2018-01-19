using System.Threading.Tasks;

namespace Beveiliging
{
    public interface IAanUitSensorCommunicatie
    {
        Task Zet(AanUitWaarde waarde);
        Task<AanUitWaarde> Lees();
    }
}