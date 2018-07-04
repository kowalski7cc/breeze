using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace Breeze.Library.Utils
{
    public class DaikinDecoder
    {
        public static DaikinData Decode(string data)
        {
            var daikinData = new DaikinData();
            string[] entries = data.Split(',');
            foreach(string entry in entries)
            {
                String[] value = entry.Split('=');
                switch (value[0])
                {
                    case "pow":
                        daikinData.PowerStatus 
                            = value[1] == "0" ? 
                            Options.PowerStatus.Off : Options.PowerStatus.On;
                        break;

                    case "mode":
                        switch (value[1])
                        {
                            case "2":
                                daikinData.Mode = Options.Mode.Dry;
                                break;
                            case "3":
                                daikinData.Mode = Options.Mode.Cool;
                                break;
                            case "4":
                                daikinData.Mode = Options.Mode.Heat;
                                break;
                            case "6":
                                daikinData.Mode = Options.Mode.Fan;
                                break;
                            default:
                                daikinData.Mode = Options.Mode.Auto;
                                break;
                        }
                        break;

                    case "f_rate":
                        switch (value[1])
                        {
                            case "A":
                                daikinData.FanSpeed = Options.FanSpeed.Auto;
                                break;
                            case "B":
                                daikinData.FanSpeed = Options.FanSpeed.None;
                                break;
                            case "3":
                                daikinData.FanSpeed = Options.FanSpeed.F1;
                                break;
                            case "4":
                                daikinData.FanSpeed = Options.FanSpeed.F2;
                                break;
                            case "5":
                                daikinData.FanSpeed = Options.FanSpeed.F3;
                                break;
                            case "6":
                                daikinData.FanSpeed = Options.FanSpeed.F4;
                                break;
                            case "7":
                                daikinData.FanSpeed = Options.FanSpeed.F5;
                                break;
                        }
                        break;

                    case "f_dir":
                        switch (value[1])
                        {
                            case "0":
                                daikinData.FanDirection = Options.FanDirection.None;
                                break;
                            case "1":
                                daikinData.FanDirection = Options.FanDirection.Vertical;
                                break;
                            case "2":
                                daikinData.FanDirection = Options.FanDirection.Horizontal;
                                break;
                            case "3":
                                daikinData.FanDirection = Options.FanDirection.Vertical;
                                break;
                            default:
                                daikinData.FanDirection = Options.FanDirection.None;
                                break;
                        }
                        break;

                    case "name":
                        daikinData.Name = WebUtility.UrlDecode(value[1]);
                        break;

                    // Target temperature
                    case "stemp":
                        daikinData.Temperature.Target
                            = (value[1].Equals("M")||value[1].Equals("--"))
                            ? (float?) null
                            : float.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    case "grp_name":
                        daikinData.GroupName = WebUtility.UrlDecode(value[1]);
                        break;

                    // Target Humidity
                    case "shum":
                        daikinData.Humidity.Target
                            = (value[1].Equals("--"))
                            ? (int?) null
                            : int.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    case "mac":
                        daikinData.Mac = value[1];
                        break;

                    // Actual temperature
                    case "htemp":
                        daikinData.Temperature.Actual
                            = float.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    // Outside acutal temperature
                    case "otemp":
                        daikinData.Temperature.Outside
                            = float.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    // Auto value
                    case "dt1":
                        daikinData.Temperature.AutoValue
                            = float.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    // Cool value
                    case "dt3":
                        daikinData.Temperature.CoolValue
                            = float.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    // Heat value
                    case "dt4":
                        daikinData.Temperature.HeatValue
                            = float.Parse(value[1], CultureInfo.InvariantCulture);
                        break;

                    case "port":
                        daikinData.Port = int.Parse(value[1]);
                        break;

                    case "adv":
                        switch (value[1])
                        {
                            case "":
                                daikinData.SpecialMode = Options.SpecialMode.None;
                                break;
                            case "1":
                                daikinData.SpecialMode = Options.SpecialMode.Powerful;
                                break;
                            case "12":
                                daikinData.SpecialMode = Options.SpecialMode.Powerful;
                                break;
                            default:
                                daikinData.SpecialMode = Options.SpecialMode.Powerful;
                                break;
                        }
                        break;
                }
            }
            return daikinData;
        }
    }
}
