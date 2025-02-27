using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;

namespace RapidApi.WebUI.Controllers
{
    public class İmdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb236.p.rapidapi.com/imdb/top250-movies"),
                Headers =
    {
        { "x-rapidapi-key", "61612a3788msh4b0bdf93637d781p1ab924jsn60c8aa167719" },
        { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonbody = await response.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<İmdbViewModel.Movie>>(jsonbody);

                var dramList = values.Where(x=> x.genres.Contains("Drama")).ToList();   
                return View(dramList);
            }
           
        }
    }
}
