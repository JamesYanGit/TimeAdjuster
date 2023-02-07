using System.IO;
using System.Net;
using System.Text.Json;
using TimeAdjuster.Interface;
using TimeAdjuster.Model;

namespace TimeAdjuster.Adjuster
{
    public class WorldTimeAdjuester:IAdjuster
    {
        string _timeURL = "http://worldtimeapi.org/api/timezone/America/Halifax";
        public WorldTimeAdjuester()
        {

        }

        public string getMins()
        {
            string ta = getTimeInfo();
            return ta.Substring(ta.Length - 2, 2);
        }
        private string getTimeInfo()
        {
            WebRequest request = WebRequest.Create(_timeURL);
            WebResponse response = request.GetResponse();
            Stream webstream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(webstream);
            WorldTimeModel worldTime = JsonSerializer.Deserialize<WorldTimeModel>(streamReader.ReadToEnd());
            return worldTime.unixtime.ToString();
        }
    }
}
