using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breeze.Library.Options
{
    public class Temperature
    {
        /** stemp */
        public float? Target { get; set; }
        /** htemp value */
        public float Actual { get; set; }
        /** otemp value */
        public float Outside { get; set; }

        /** dt1 value */
        public float AutoValue { get; set; }
        /** dt3 value */
        public float CoolValue { get; set; }
        /** dt4 value */
        public float HeatValue { get; set; }

        public float? GetTargetTemp(Mode mode)
        {
            if(Target==0)
            {
                switch(mode)
                {
                    case Mode.Auto:
                        return AutoValue;
                    case Mode.Cool:
                        return CoolValue;
                    case Mode.Heat:
                        return HeatValue;
                    default:
                        return null;
                }
            }
            else
            {
                return Target;
            }
        }

        public String GetTargetPostOption(Mode mode)
        {
            if(Target!=null)
            {
                switch (mode)
                {
                    case Mode.Auto:
                        return "stemp=" + (int)AutoValue;
                    case Mode.Cool:
                        return "stemp=" + (int)CoolValue;
                    case Mode.Heat:
                        return "stemp=" + (int)HeatValue;
                    case Mode.Dry:
                        return "stemp=M";
                    case Mode.Fan:
                        return "stemp=--";
                }
                throw new ArgumentException();
            }
            else
            {
                return "stemp=" + (int)Target;
            }
        }
    }
}
