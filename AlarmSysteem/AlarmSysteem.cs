using System;
using System.Collections.Generic;
using System.Linq;

namespace Beveiliging
{
    public class IEvenementen
    {
        
    }

    public class AlarmSysteem
    {
        private readonly List<HueLamp> _hueLampen = new List<HueLamp>();
        private readonly List<AanUitSensor> _aanUitSensoren = new List<AanUitSensor>();

        protected AanUitSensor BewegingSensor(string naam, IAanUitSensorCommunicatie communicatie)
        {
            return _aanUitSensoren.FirstOrDefault(z => z.Naam == naam) ??
                   _aanUitSensoren.AddAndReturn(new AanUitSensor(naam, communicatie));
        }


        protected HueLamp HueLamp(string naam, IHueLampCommunicatie communicatie)
        {
            return _hueLampen.FirstOrDefault(z => z.Naam == naam) ??
                   _hueLampen.AddAndReturn(new HueLamp(naam, communicatie));
        }
    }
}
