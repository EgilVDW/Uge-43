using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassForFirstSem
{
    public class PullData
    {
        public async Task<List<string>> GetDataAsync()
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync("http://gruppe2.simonstochholm.dk/api/csv");
            response.EnsureSuccessStatusCode();
            var jsonRespone = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var Data = JsonSerializer.Deserialize<List<string>>(jsonRespone, options);

            return Data;
        }

        public async Task DoThingAsync()
        {
            List<string> data = await GetDataAsync();
            string[] tempArray;
            string[] temp = data.ToArray();
            string[] meterID = new string[temp.Length];
            DateTime[] fromData = new DateTime[temp.Length];
            DateTime[] toDate = new DateTime[temp.Length];
            string[] value = new string[temp.Length];

            for (int i = 1; i < temp.Length; i++)
            {
                tempArray = temp[i].Split(";");
                meterID[i] = tempArray[1];
                fromData[i] = DateTime.ParseExact(tempArray[2], "yyyy-MM-dd HH,mm", CultureInfo.InvariantCulture);
                toDate[i] = DateTime.ParseExact(tempArray[3], "yyyy-MM-dd HH,mm", CultureInfo.InvariantCulture);
                value[i] = tempArray[4];
            }
            var indexes = FilterByDate(DateTime.Parse("2020-11-30"), DateTime.Parse("2020-12-30"), fromData);
            foreach (var index in indexes)
            {
                Console.WriteLine(index);
            }
        }

        public List<int> FilterByDate(DateTime startDate, DateTime endDate, DateTime[] fromDate)
        {
            List<int> data = new List<int>();
            for (int i = 0; i < fromDate.Length; i++)
            {
                if (DateTime.Compare(fromDate[i],startDate) > 0 && DateTime.Compare(endDate, fromDate[i]) > 0)
                {
                    data.Add(i);
                }
            }
            return data;
        }
    }
}
