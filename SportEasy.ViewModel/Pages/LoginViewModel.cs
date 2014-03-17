using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SportEasy.Model.Data;
using SportEasy.Model.Localization;
using SportEasy.Model.Navigation;

namespace SportEasy.ViewModel.Pages
{
    public class LoginViewModel : GlobalViewModel
    {
        #region Variable declaration

        private LoginViewEnum _loginView;
        private string _email;
        private string _firstname;
        private string _lastname;
        private string _password;
        private string _passwordConfirmed;
        private IDataService _dataService;
        private bool _showPopup;
        private string _popupMessage;

        #endregion

        #region Properties

        public LoginViewEnum LoginView
        {
            get { return _loginView; }
            set
            {
                _loginView = value;
                RaisePropertyChanged();
            }
        }

        #region Formular

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                RaisePropertyChanged();
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public string PasswordConfirmed
        {
            get { return _passwordConfirmed; }
            set
            {
                _passwordConfirmed = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Popup

        public bool ShowPopup
        {
            get { return _showPopup; }
            set
            {
                _showPopup = value;
                RaisePropertyChanged();
            }
        }

        public string PopupMessage
        {
            get { return _popupMessage; }
            set
            {
                _popupMessage = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #endregion

        #region Command

        public ICommand ShowLoginCommand { get; set; }
        public ICommand ShowRegisterCommand { get; set; }
        public ICommand LogIn { get; set; }
        public ICommand Register { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel(IDataService dataService)
        {
            _dataService = dataService;

            #region Command Initialization

            ShowLoginCommand = new RelayCommand(OnShowLoginCommand);
            ShowRegisterCommand = new RelayCommand(OnShowRegisterCommand);
            LogIn = new RelayCommand(OnLogIn);
            Register = new RelayCommand(OnRegister);

            #endregion

            if(IsInDesignMode)
            {
                LoginView = LoginViewEnum.Login;
                PopupMessage = AppResources.string_MissingFirstname;
                ShowPopup = true;
            }
        }

        #endregion

        #region Business

        #region Command callback

        private void OnShowRegisterCommand()
        {
            LoginView = LoginViewEnum.Register;
        }

        private void OnShowLoginCommand()
        {
            LoginView = LoginViewEnum.Login;
        }

        private void OnRegister()
        {
            PopupMessage = string.Empty;

            // Validate fields
            if (string.IsNullOrEmpty(_passwordConfirmed))
                PopupMessage = AppResources.string_MissingPasswordConfirmed;
            if (string.IsNullOrEmpty(_password))
                PopupMessage = AppResources.string_MissingPassword;
            if (string.IsNullOrEmpty(_email))
                PopupMessage = AppResources.string_MissingEmail;
            if (string.IsNullOrEmpty(_lastname))
                PopupMessage = AppResources.string_MissingLastname;
            if (string.IsNullOrEmpty(_firstname))
                PopupMessage = AppResources.string_MissingFirstname;

            if (!string.IsNullOrEmpty(PopupMessage))
            {
                ShowPopup = true;
                return;
            }

            _dataService.Register(_firstname, _lastname, _email, _password);
        }

        private void OnLogIn()
        {
            PopupMessage = string.Empty;

            // Validate fields
            if (string.IsNullOrEmpty(_password))
                PopupMessage = AppResources.string_MissingPassword;
            if (string.IsNullOrEmpty(_email))
                PopupMessage = AppResources.string_MissingEmail;

            if (!string.IsNullOrEmpty(PopupMessage))
            {
                ShowPopup = true;
                return;
            }

            var user = _dataService.LogIn(_email, _password);

            OnNavigate(new NavigationEventHandler(typeof(MainViewModel), user));
        }

        #endregion

        #endregion
    }

    public enum LoginViewEnum
    {
        Home,
        Login,
        Register
    }
}