using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Services.Configuration
{
	public interface IConfigurationService
	{
		string GetConfigurationValue(string key);
	}
}
