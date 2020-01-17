using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Represents all rows of Berlin clock
    /// </summary>
    public class BerlinClockPrototype 
    {
        public SecondsClockRows SecondsRows => (SecondsClockRows)AllRows.First(r => r is SecondsClockRows);
        /// <summary>
        /// Rows that indicate minutes(2 rows)
        /// </summary>
        public MinutesClockRows[] MinutesRows => AllRows.Where(r => r is MinutesClockRows).Cast<MinutesClockRows>().ToArray();
        /// <summary>
        /// Rows that indicate hours(2 rows)
        /// </summary>
        public HoursClockRows[] HoursRows => AllRows.Where(r => r is HoursClockRows).Cast<HoursClockRows>().ToArray();
        public IEnumerable<ClockRowBase> AllRows { get; set; }
        public BerlinClockPrototype()
        {
            AllRows = new List<ClockRowBase> {
                                                new SecondsClockRows(),
                                                new HoursClockRows(false),
                                                new HoursClockRows(true),
                                                new MinutesClockRows(false),
                                                new MinutesClockRows(true),
                                                
                                             };
        }

        public override string ToString()
        {
            return string.Join("\r\n", AllRows.Select(r => r.ToString())); 
        }
    }
}
