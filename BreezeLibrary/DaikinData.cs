using Breeze.Library.Options;

namespace Breeze.Library
{
    public class DaikinData
    {
        public DaikinData()
        {
            Temperature = new Temperature();
            Humidity = new Humidity();
        }
        public PowerStatus PowerStatus { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Mac { get; set; }
        public int? Port { get; set; }
        public FanSpeed FanSpeed { get; set; }
        public FanDirection FanDirection { get; set; }
        public Mode Mode { get; set; }
        public Temperature Temperature { get; set; }
        public Humidity Humidity { get; set; }
        public SpecialMode SpecialMode { get; set; }

        public float? GetTargetTemperature(Mode mode)
        {
            switch (mode)
            {
                case Mode.Auto:
                    return Temperature.AutoValue;
                case Mode.Cool:
                    return Temperature.CoolValue;
                case Mode.Heat:
                    return Temperature.HeatValue;
                default:
                    return null;
            }
        }

        public float? GetTargetTemperature()
        {
            switch (Mode)
            {
                case Mode.Auto:
                    return Temperature.AutoValue;
                case Mode.Cool:
                    return Temperature.CoolValue;
                case Mode.Heat:
                    return Temperature.HeatValue;
                default:
                    return null;
            }
        }
    }
}