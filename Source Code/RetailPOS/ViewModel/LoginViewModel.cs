using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Windows;
using RetailPOS.View;

namespace RetailPOS.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public ObservableCollection<StaffDTO> lstUsers { get; private set; }
        public RelayCommand<StaffDTO> SelectUserCommand { get; private set; }
        public RelayCommand <object> LoginCommand { get; private set; }

        private string _fullName;
        private string _userName;
        private string _password;
        private bool _isEnabled;
        private Visibility _messageVisibility;
            
        #endregion

        #region Public Properties

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                RaisePropertyChanged("FullName");
            }
        }

        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public Visibility MessageVisibility
        {
            get { return _messageVisibility ; }
            set 
            { 
                _messageVisibility = value;
                RaisePropertyChanged("MessageVisibility");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            MessageVisibility = Visibility.Hidden;
            lstUsers = new ObservableCollection<StaffDTO>();
            GetUsers();

            SelectUserCommand = new RelayCommand<StaffDTO>(SelectedUserName);
            LoginCommand = new RelayCommand<object>(ValidateUserCredentials);
        }

        #endregion

        /// <summary>
        /// Checks the user exists.
        /// </summary>
        private void ValidateUserCredentials(object passwordDetails)
        {
            var passwordBox = passwordDetails as PasswordBox;
            Password = passwordBox.Password;

            bool isUserValidate = ServiceFactory.ServiceClient.ValidateUserCredentials(UserName, Password);
            
            if (!isUserValidate)
            {
                MessageVisibility = Visibility.Visible;
            }
            else
            {
                ////Sets the message visibility as hidden
                MessageVisibility = Visibility.Hidden;
                
                ////Opens up main window
                var mainWindow = new MainWindow();
                mainWindow.Show();

                ////Closes login window
                LoginWindow._LoginWindow.Close();
            }
        }

        /// <summary>
        /// Selecteds the name of the user.
        /// </summary>
        /// <param name="userDT">The user DT.</param>
        private void SelectedUserName(StaffDTO userDetails)
        {
            UserName = userDetails.UserName;
        }

        /// <summary>
        /// Get the users.
        /// </summary>
        private void GetUsers()
        {
            lstUsers = new ObservableCollection<StaffDTO>(from item in ServiceFactory.ServiceClient.GetStaffDetails()
                                                          select item);
        }
    }
}