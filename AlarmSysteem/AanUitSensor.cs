namespace Beveiliging
{
    public class AanUitSensor
    {
        public string Naam { get; }
        public IAanUitSensorCommunicatie Communicatie { get; }

        public AanUitSensor(string naam,IAanUitSensorCommunicatie communicatie)
        {
            Naam = naam;
            Communicatie = communicatie;
        }
    }
}