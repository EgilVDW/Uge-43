using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project
{
    public class APIRepository : IRepository
    {
        List<Usage> usages = new List<Usage>();

        public APIRepository()
        {
            var result = GetDataAsync();
            result.Wait();
        }

        private async Task GetDataAsync()
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

            Usage tempUsage = new Usage();
            Meter tempMeter = new Meter(-1);
            string[] splittedEntry;
            foreach (string item in Data)
            {
                splittedEntry = item.Split(';');
                tempMeter = new Meter(long.Parse(splittedEntry[0]));
                tempUsage = new Usage()
                {
                    Id = tempMeter,
                    Date = DateTime.ParseExact(splittedEntry[1], "yyyy-MM-dd HH,mm", CultureInfo.InvariantCulture),
                    Amount = double.Parse(splittedEntry[3])
                };
                usages.Add(tempUsage);
            }
        }

        public List<Usage> Read(Meter meter)
        {
            throw new NotImplementedException();
        }

        public List<Usage> Read(Meter meter, DateTime dateTime, DateTime dateTime1)
        {
            throw new NotImplementedException();
        }
    }
}
