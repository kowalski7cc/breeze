using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Breeze.Library.Utils;

namespace Breeze.Library
{

    public class Daikin
    {

        public Daikin(string host)
        {
            Host = host;
        }

        private string[] urls =
        {
            "/common/basic_info",
            "/aircon/get_sensor_info",
            "/aircon/get_control_info"
        };
        public string Host { get; set; }

        public async Task<DaikinData> GetStatus()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(string request in urls)
            {
                var http = new HttpClient();
                var response = await http.GetStringAsync("http://" + Host + request);
                Debug.WriteLine(response);
                stringBuilder.Append(response + ",");
            }
            return DaikinDecoder.Decode(stringBuilder.ToString());
        }

        public void SetStatus(DaikinData Data)
        {
            String message;
        }
    }
}