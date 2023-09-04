using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClothingSuggestionAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClothingController : ControllerBase
	{
		private readonly HttpClient _httpClient;

		public ClothingController(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient();
		}

		[HttpGet]
		public async Task<IActionResult> Get(string city)
		{
			var apiKey = "9022eac2dbd2e09f279a7a43f98bf74f";
			var weatherApiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

			var response = await _httpClient.GetAsync(weatherApiUrl);

			if (!response.IsSuccessStatusCode)
			{
				return BadRequest();
			}

			var weatherData = await response.Content.ReadAsAsync<WeatherData>();
			var temperature = weatherData.Main.Temp - 273.15m ;
			string suggestion;
			if (temperature <= 10)
			{
				suggestion = "Wear a heavy jacket, gloves, and a scarf";
			}
			else if (temperature <= 20)
			{
				suggestion = "Wear a light jacket or a sweater";
			}
			else if (temperature <= 30)
			{
				suggestion = "Wear shorts and a t-shirt";
			}
			else
			{
				suggestion = "Wear light and loose clothing";
			}

			return Ok(suggestion);
		}
	}
}
