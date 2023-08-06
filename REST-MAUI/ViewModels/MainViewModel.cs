using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST_MAUI.HException;
using REST_MAUI.Models;
using REST_MAUI.Repository.UserRepository;
using System.Windows.Input;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace REST_MAUI.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class MainViewModel
	{
		private readonly IUserRepository _userRepository;

		public MainViewModel(IUserRepository userRepository)
		{
			_userRepository = userRepository;
			GetAllUsersCommand = new Command(async () => await LoadUsersAsync());
			StoreUserAsyncCommand = new Command(async () => await StoreUserAsync());
		}

		public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
		public string ErrorMessage { get; set; }

		public ICommand GetAllUsersCommand { get; }
		public ICommand StoreUserAsyncCommand { get; }

		private async Task LoadUsersAsync()
		{
			try
			{
				Users = new ObservableCollection<User>(await _userRepository.GetUsersAsync());
				ErrorMessage = null; // Clear any previous error messages
			}
			catch (UserRepositoryException ex)
			{
				ErrorMessage = ex.Message;
			}
		}

		private async Task StoreUserAsync()
		{
			try
			{
				var res = await _userRepository.StoreUserAsync(new User()
				{
					Id = "222",
					Avatar = "none",
					CreatedAt = DateTime.Now,
					Name = "Basurto"
				});

				if (res != null && (res as User) != null)
				{
					this.Users.Add(res);
				}

				ErrorMessage = null; // Clear any previous error messages
			}
			catch (UserRepositoryException ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
