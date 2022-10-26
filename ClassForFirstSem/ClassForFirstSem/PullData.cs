﻿using System;
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
    }
}
