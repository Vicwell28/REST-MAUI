using SkiaSharp.Extended.UI.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Converters
{
	public class CodeToLottieConverter : IValueConverter
	{
		private readonly Dictionary<float, string> _lottieFiles = new Dictionary<float, string>
		{
			{ 0, "sunny.json" },
			{ 1, "sunny.json" },
			{ 2, "foggy.json" },
			{ 3, "foggy.json" },
			{ 45, "foggy.json" },
			{ 48, "foggy.json" },
			{ 51, "partly-shower.json" },
			{ 53, "partly-shower.json" },
			{ 55, "partly-shower.json" },
			{ 56, "partly-shower.json" },
			{ 57, "partly-shower.json" },
			{ 61, "stormshowersday.json" },
			{ 63, "stormshowersday.json" },
			{ 65, "stormshowersday.json" },
			{ 66, "snow.json" },
			{ 67, "snow.json" },
			{ 71, "snow.json" },
			{ 73, "snow.json" },
			{ 75, "snow.json" },
			{ 77, "snow.json" },
			{ 80, "storm.json" },
			{ 81, "storm.json" },
			{ 82, "storm.json" },
			{ 85, "storm.json" },
			{ 86, "storm.json" },
			{ 95, "storm.json" },
			{ 96, "storm.json" },
			{ 99, "storm.json" },
		};

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is float code && _lottieFiles.ContainsKey(code))
			{
				var lottieImageSource = new SKFileLottieImageSource
				{
					File = _lottieFiles[code]
				};
				return lottieImageSource;
			}

			return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
