using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;
using System.Net.Http.Headers;

namespace RapidApiProject.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=USD&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "ed120ca162msh4a2cf1663625a24p1cae18jsn548260e0d857" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExhangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
        }
    }
}
