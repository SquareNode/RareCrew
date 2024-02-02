using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RareCrew
{
    internal class Cotroller
    {

        public static void start()
        {
            var data = Model.getData();
            var parsedData = parse(data);
            View.createHTML(parsedData);
        }

        public static SortedList<int, string> parse(string json)
        {
            var objects = JArray.Parse(json);                              
            Dictionary<string, int> namesAndTimes = new Dictionary<string, int>();

            foreach (JObject root in objects)
            {
                var name = (string)root.GetValue("EmployeeName");
                if (name == null)
                    continue;

                var startTime = root.GetValue("StarTimeUtc");
                var endTime = root.GetValue("EndTimeUtc");

                var time = calcTime((string)startTime, (string)endTime);
                if (time < 0)
                    continue;

                if (namesAndTimes.ContainsKey(name))
                {
                    namesAndTimes[name] += time;
                }
                else
                {
                    namesAndTimes[name] = time;
                }
            }

            SortedList<int, string> result = new SortedList<int, string>();

            foreach (var pair in namesAndTimes)
                result.Add(pair.Value, pair.Key);

            return result;

        }

        public static int calcTime(string startTime, string endTime)
        {

            var start = DateTimeOffset.Parse(startTime).UtcDateTime;
            var end = DateTimeOffset.Parse(endTime).UtcDateTime;

            var res = end - start;

            return (int)res.TotalMinutes;

        }


    }
}
