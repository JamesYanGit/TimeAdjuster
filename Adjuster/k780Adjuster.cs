using System.Text.Json;
using System;
using System.IO;
using System.Net;
using TimeAdjuster.Interface;
using TimeAdjuster.Model;

namespace TimeAdjuster.Adjuster
{
    public class k780Adjuster : IAdjuster
    {
        string _timeURL = "http://api.k780.com/?app=time.world&city_en=new-york&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=json";
        public k780Adjuster() 
        {
            
        }

        public string getMins()
        {
            string ta = getTimeInfo();
            return ta.Substring(ta.Length-2, 2);
        }
        private string getTimeInfo() 
        {
            WebRequest request = WebRequest.Create(_timeURL);
            WebResponse response = request.GetResponse();
            Stream webstream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(webstream);
            K780Model k780Time = JsonSerializer.Deserialize<K780Model>(streamReader.ReadToEnd());
            return k780Time.result.timestamp;
        }
    }
}
