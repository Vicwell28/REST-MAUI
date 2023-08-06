using Microsoft.Extensions.Configuration;
using REST_MAUI.Models;
using System.Text;
using System.Text.Json;
using global::REST_MAUI.HException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace REST_MAUI.Services.ApiService
{
	public class ApiService : IApiService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;
		private readonly string ApiUrl;

		public ApiService(IConfiguration configurationService)
		{
			_httpClient = new HttpClient();
			_serializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
			ApiEndpoint ApiEndpoint = configurationService.GetRequiredSection("ApiEndpoint").Get<ApiEndpoint>();
			this.ApiUrl = $"{ApiEndpoint.Endpoint}{ApiEndpoint.Prefix}{ApiEndpoint.Version}";
		}

		private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync())
				{
					return await JsonSerializer.DeserializeAsync<T>(responseStream, _serializerOptions);
				}
			}
			else
			{
				string errorContent = await response.Content.ReadAsStringAsync();
				throw new ApiException($"API request failed: {response.StatusCode} - {errorContent}");
			}
		}

		public async Task<List<User>> GetUsersAsync()
		{
			try
			{
				var uri = new Uri($"{ApiUrl}/users");
				var response = await _httpClient.GetAsync(uri);
				response.EnsureSuccessStatusCode();
				return await HandleResponseAsync<List<User>>(response);
			}
			catch (Exception ex)
			{
				throw new ApiException("An error occurred while getting users from API.", ex);
			}
		}

		public async Task<User> GetUserAsync(int userId)
		{
			try
			{
				var uri = new Uri($"{ApiUrl}/users/{userId}");
				var response = await _httpClient.GetAsync(uri);
				response.EnsureSuccessStatusCode();
				return await HandleResponseAsync<User>(response);
			}
			catch (Exception ex)
			{
				throw new ApiException("An error occurred while getting user details from API.", ex);
			}
		}

		public async Task<User> UpdateUserAsync(User user)
		{
			try
			{
				var uri = new Uri($"{ApiUrl}/users/{user.Id}");
				var json = JsonSerializer.Serialize(user, _serializerOptions);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _httpClient.PutAsync(uri, content);
				response.EnsureSuccessStatusCode();
				return await HandleResponseAsync<User>(response);
			}
			catch (Exception ex)
			{
				throw new ApiException("An error occurred while updating user in API.", ex);
			}
		}

		public async Task<bool> DeleteUserAsync(int userId)
		{
			try
			{
				var uri = new Uri($"{ApiUrl}/users/{userId}");
				var response = await _httpClient.DeleteAsync(uri);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				throw new ApiException("An error occurred while deleting user from API.", ex);
			}
		}

		public async Task<User> StoreUserAsync(User user)
		{
			try
			{
				var uri = new Uri($"{ApiUrl}/users");
				var json = JsonSerializer.Serialize(user, _serializerOptions);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync(uri, content);
				response.EnsureSuccessStatusCode();
				return await HandleResponseAsync<User>(response);
			}
			catch (Exception ex)
			{
				throw new ApiException("An error occurred while storing user in API.", ex);
			}
		}
	}
}
