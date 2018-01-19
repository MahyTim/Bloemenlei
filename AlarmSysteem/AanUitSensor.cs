namespace Beveiliging
{
    public class AanUitSensor
    {
        public string Naam { get; }
        private readonly IAanUitSensorCommunicatie _communicatie;

        public AanUitSensor(string naam,IAanUitSensorCommunicatie communicatie)
        {
            Naam = naam;
            _communicatie = communicatie;
        }
    }
}