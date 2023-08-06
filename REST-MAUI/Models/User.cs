using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Models
{
	[AddINotifyPropertyChangedInterface]
	public class User
	{
		public string Name { get; set; }
		public string Avatar { get; set; }
		public string Id { get; set; }
		public DateTime CreatedAt { get; set; }
	}

}
