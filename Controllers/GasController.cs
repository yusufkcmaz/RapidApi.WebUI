using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;
using System.Runtime.InteropServices.JavaScript;

namespace RapidApi.WebUI.Controllers
{
    public class GasController : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
    {
        { "x-rapidapi-key", "61612a3788msh4b0bdf93637d781p1ab924jsn60c8aa167719" },
        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values  = JsonConvert.DeserializeObject<GasPriceViewModel>(body);
                return View(values.results);
            }
           
        }
    }
}
