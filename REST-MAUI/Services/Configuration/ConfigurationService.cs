using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Services.Configuration
{
	public class ConfigurationService : IConfigurationService
	{
		private readonly IConfiguration _configuration;

		public ConfigurationService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GetConfigurationValue(string key)
		{
			return _configuration[key];
		}
	}
}
