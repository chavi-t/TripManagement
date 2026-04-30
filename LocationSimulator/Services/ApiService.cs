using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using LocationSimulator.Models;

namespace LocationSimulator.Services
{
    class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<StudentFromApi>> GetStudents()
        {
            var response = await _http.GetStringAsync("https://localhost:7115/api/Student");
            return JsonConvert.DeserializeObject<List<StudentFromApi>>(response);
        }

        public async Task SendLocation(object payload)
        {
            var json = JsonConvert.SerializeObject(payload);

            var response = await _http.PostAsync(
                "https://localhost:7115/api/location",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            Console.WriteLine($"Sent → {response.StatusCode}");
        }
    }
}
