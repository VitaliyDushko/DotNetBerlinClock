using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Imcapsulates methods and properties all rows implement
    /// </summary>
    public abstract class ClockRowBase
    {
        public List<ClockLampBase> Lamps { get; set; } = new List<ClockLampBase>();
        protected void AddLamps<T>(short lampValue, int lampsNumber) where T : ClockLampBase
        {
            for (int i = 0; i < lampsNumber; i++)
            {
                Lamps.Add((T)Activator.CreateInstance(typeof(T), lampValue));
            }
        }

        public override string ToString()
        {
            return string.Join(string.Empty, Lamps.Select(l => $"{(l.On ? l.Color.ToString() : "O")}"));
        }
    }

    /// <summary>
    /// Initializes row instance that represents seconds
    /// </summary>
    public class SecondsClockRows : ClockRowBase
    {
        public SecondsClockRows()
        {
            AddLamps<ClockYellowLamp>(2, 1);
        }
    }

    /// <summary>
    /// Initializes row instance that represents hours
    /// </summary>
    public class HoursClockRows : ClockRowBase
    {
        public HoursClockRows(bool secondRow)
        {
            if (!secondRow)
            {
                AddLamps<ClockLampRedLamp>(5, 4);
            }
            else
            {
                AddLamps<ClockLampRedLamp>(1, 4);
            }
        }
    }

    /// <summary>
    /// Initializes row instance that represents minutes
    /// </summary>
    public class MinutesClockRows : ClockRowBase
    {
        public MinutesClockRows(bool secondRow)
        {
            if (!secondRow)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (i == 2 || i == 5 || i == 8)
                    {
                        Lamps.Add(new ClockLampRedLamp(5));
                    }
                    else
                    {
                        Lamps.Add(new ClockYellowLamp(5));
                    }
                }
            }
            else
            {
                AddLamps<ClockYellowLamp>(1, 4);
            }
        }
    }
}
