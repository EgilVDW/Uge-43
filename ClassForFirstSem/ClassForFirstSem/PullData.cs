using System;
using System.Collections.Generic;
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
            string[] fromData = new string[temp.Length];
            string[] toDate = new string[temp.Length];
            string[] value = new string[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                tempArray = temp[i].Split(";");
                meterID[i] = tempArray[0];
                fromData[i] = tempArray[1];
                toDate[i] = tempArray[2];
                value[i] = tempArray[3];
                Console.WriteLine(temp[i]);
            }
        }
    }
}
