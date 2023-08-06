using REST_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Services.ApiService
{
	public interface IApiService
	{
		Task<List<User>> GetUsersAsync();
		Task<User> GetUserAsync(int userId);
		Task<User> UpdateUserAsync(User user);
		Task<bool> DeleteUserAsync(int userId);
		Task<User> StoreUserAsync(User user);
	}
}
