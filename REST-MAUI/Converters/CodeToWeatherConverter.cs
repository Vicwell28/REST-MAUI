using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Converters
{
	public class CodeToWeatherConverter : IValueConverter
	{
		private readonly Dictionary<float, string> _weatherDescriptions = new Dictionary<float, string>
		{
			{ 0, "Clear Sky" },
			{ 1, "Mainly Clear" },
			{ 2, "Partly Cloudy" },
			{ 3, "Overcast" },
			{ 45, "Fog" },
			{ 48, "Depositing rime fog" },
			{ 51, "Drizzle: Light" },
			{ 53, "Drizzle: Moderate" },
			{ 55, "Drizzle: Dense Intensity" },
			{ 56, "Freezing Drizzle: Light" },
			{ 57, "Freezing Drizzle: Dense Intensity" },
			{ 61, "Rain: Slight" },
			{ 63, "Rain: Moderate" },
			{ 65, "Rain: Heavy Intensity" },
			{ 66, "Freezing Rain: Light" },
			{ 67, "Freezing Rain: Heavy Intensity" },
			{ 71, "Snow fall: Slight" },
			{ 73, "Snow fall: Moderate" },
			{ 75, "Snow fall: Heavy Intensity" },
			{ 77, "Snow grains" },
			{ 80, "Rain showers: Slight" },
			{ 81, "Rain showers: Moderate" },
			{ 82, "Rain showers: Violent" },
			{ 85, "Snow showers: Slight" },
			{ 86, "Snow showers: Heavy" },
			{ 95, "Thunderstorm: Slight or moderate" },
			{ 96, "Thunderstorm with slight and heavy hail" },
			{ 99, "Thunderstorm with slight and heavy hail" },
		};

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is float code && _weatherDescriptions.ContainsKey(code))
			{
				return _weatherDescriptions[code];
			}

			return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
