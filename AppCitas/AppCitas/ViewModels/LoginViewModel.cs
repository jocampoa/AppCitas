﻿namespace AppCitas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Services;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        //private DataService dataService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            //this.dataService = new DataService();

            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "EmailValidation",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "EmailValidation",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if(this.Email != "juan@gmail.com" || this.Password != "123456")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "error",
                    "EmailValidation",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error", //Languages.Error,
            //        connection.Message,
            //         "Accept"); //Languages.Accept);
            //    return;
            //}

            //var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            //var token = await this.apiService.GetToken(
            //    apiSecurity,
            //    this.Email,
            //    this.Password);

            //if (token == null)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error", //Languages.Error,
            //        "SomethingWrong", //Languages.SomethingWrong,
            //        "Accept"); //Languages.Accept);
            //    return;
            //}

            //if (string.IsNullOrEmpty(token.AccessToken))
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error", //Languages.Error,
            //        "LoginError", //Languages.LoginError,
            //        "Accept"); //Languages.Accept);
            //    this.Password = string.Empty;
            //    return;
            //}

            //var user = await this.apiService.GetUserByEmail(
            //    apiSecurity,
            //    "/api",
            //    "/Users/GetUserByEmail",
            //    token.TokenType,
            //    token.AccessToken,
            //    this.Email);

            //var userLocal = Converter.ToUserLocal(user);
            //userLocal.Password = this.Password;

            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = token;
            //mainViewModel.User = userLocal;

            //if (this.IsRemembered)
            //{
            //    Settings.IsRemembered = "true";
            //}
            //else
            //{
            //    Settings.IsRemembered = "false";
            //}

            //this.dataService.DeleteAllAndInsert(userLocal);
            //this.dataService.DeleteAllAndInsert(token);

            mainViewModel.Citas = new CitasViewModel();
            Application.Current.MainPage = new MasterPage();

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        //public ICommand RegisterCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(Register);
        //    }
        //}

        //private async void Register()
        //{
        //    MainViewModel.GetInstance().Register = new RegisterViewModel();
        //    await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        //}
        #endregion

    }
}