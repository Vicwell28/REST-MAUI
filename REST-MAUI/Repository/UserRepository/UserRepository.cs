using REST_MAUI.Models;
using REST_MAUI.Services.ApiService;
using REST_MAUI.HException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_MAUI.Repository.UserRepository
{
	public class UserRepository : IUserRepository
	{
		private readonly IApiService _apiService;

		public UserRepository(IApiService apiService)
		{
			_apiService = apiService;
		}

		public async Task<List<User>> GetUsersAsync()
		{
			try
			{
				return await _apiService.GetUsersAsync();
			}
			catch (ApiException ex)
			{
				throw new UserRepositoryException("An error occurred while getting users.", ex);
			}
		}

		public async Task<User> GetUserAsync(int userId)
		{
			try
			{
				return await _apiService.GetUserAsync(userId);
			}
			catch (ApiException ex)
			{
				throw new UserRepositoryException("An error occurred while getting user details.", ex);
			}
		}

		public async Task<User> UpdateUserAsync(User user)
		{
			try
			{
				return await _apiService.UpdateUserAsync(user);
			}
			catch (ApiException ex)
			{
				throw new UserRepositoryException("An error occurred while updating user.", ex);
			}
		}

		public async Task<bool> DeleteUserAsync(int userId)
		{
			try
			{
				return await _apiService.DeleteUserAsync(userId);
			}
			catch (ApiException ex)
			{
				throw new UserRepositoryException("An error occurred while deleting user.", ex);
			}
		}

		public async Task<User> StoreUserAsync(User user)
		{
			try
			{
				return await _apiService.StoreUserAsync(user);
			}
			catch (ApiException ex)
			{
				throw new UserRepositoryException("An error occurred while storing user.", ex);
			}
		}
	}
}
