using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedLibrary;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get(string city)
		{
			var apiKey = "9022eac2dbd2e09f279a7a43f98bf74f";
			var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
			var response = await new HttpClient().GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
				var temperature = weatherData.Main.Temp - 273.15m;
				return Ok(new { main = new { temp = temperature } });
			}

			return BadRequest();
		}
	}
}
