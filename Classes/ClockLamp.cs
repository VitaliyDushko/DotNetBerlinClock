using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public abstract class ClockLampBase
    {
        public readonly short lampValue;
        public ClockLampBase(short lampValue)
        {
            this.lampValue = lampValue;
        }
        public bool On { get; set; }
        public abstract LampColor Color { get; }
    }

    public class ClockLampRedLamp : ClockLampBase
    {
        public ClockLampRedLamp(short lampValue) : base(lampValue)
        {

        }
        public override LampColor Color => LampColor.R;
    }

    public class ClockYellowLamp : ClockLampBase
    {
        public ClockYellowLamp(short lampValue) : base(lampValue)
        {

        }
        public override LampColor Color => LampColor.Y;
    }
}
