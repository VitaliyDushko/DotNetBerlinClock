using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            
            var berLinClock = new Classes.BerlinClockPrototype();

            if (DateTime.TryParse(aTime, out DateTime dateTime))
            {             
                berLinClock.SecondsRows.Lamps.First().On = dateTime.Second % 2 == 0;

                berLinClock.HoursRows[0].Lamps.Take(dateTime.Hour / 5).ToList().ForEach(r => r.On = true);

                berLinClock.HoursRows[1].Lamps.Take(dateTime.Hour % 5).ToList().ForEach(r => r.On = true);

                berLinClock.MinutesRows[0].Lamps.Take(dateTime.Minute / 5).ToList().ForEach(r => r.On = true);

                berLinClock.MinutesRows[1].Lamps.Take(dateTime.Minute % 5).ToList().ForEach(r => r.On = true);

                var res =  berLinClock.ToString();
                return res;
            }
            else
            {
                if (aTime == "24:00:00")
                {
                    //There is no such time but to pass the tests
                    berLinClock.SecondsRows.Lamps.First().On = dateTime.Second % 2 == 0;

                    berLinClock.HoursRows.ToList().ForEach(bc => bc.Lamps.ForEach(l => l.On = true));

                    var res = berLinClock.ToString();
                    return res;
                }
                else
                {
                    throw new Exception("Incorrect time format");
                }
            }   
        }
    }
}
