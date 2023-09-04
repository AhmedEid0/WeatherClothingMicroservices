using System.Collections.Generic;

namespace SharedLibrary
{
	public class WeatherData
	{
		public MainData Main { get; set; }
	}

	public class MainData
	{
		public decimal Temp { get; set; }
	}
}