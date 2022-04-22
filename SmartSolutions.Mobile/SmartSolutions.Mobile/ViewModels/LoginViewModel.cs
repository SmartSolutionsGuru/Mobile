using SmartSolutions.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartSolutions.Mobile.ViewModels
{
    /// <summary>
    /// Login View Model 
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region [Properties]
        public Command LoginCommand { get; }
        //private string username;
        ///// <summary>
        ///// user Name  for Login user
        ///// </summary>
        //public string Username
        //{
        //    get { return username; }
        //    set { username = value; NotifyOfPropertyChange(nameof(Username)); }
        //}

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; NotifyOfPropertyChange(nameof(Email)); }
        }

        private string password;
        /// <summary>
        /// PAssword Of The User
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; NotifyOfPropertyChange(nameof(Password));}
        }

        #endregion

        #region [Constructor]
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        #endregion

        #region [Private Methods]
        private async void OnLoginClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            if(/*!string.IsNullOrEmpty(Username) &&*/ !string.IsNullOrEmpty(Password))
            {
                //TODO: Replace with the db Call or api call
                await Shell.Current.GoToAsync("//TabPage");
            }
        }
        #endregion

        #region [Public Methods]

        #endregion
    }
}
