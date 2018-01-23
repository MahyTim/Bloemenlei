using System.Threading.Tasks;

namespace Beveiliging.Communicatie
{
   
    public interface IAanUitSensorCommunicatie
    {
        Task<AanUitWaarde> Lees(AanUitSensor sensor);

        Task Zet(AanUitSensor sensor, AanUitWaarde waarde);
    }
}