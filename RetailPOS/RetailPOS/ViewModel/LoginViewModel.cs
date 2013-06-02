using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;


namespace RetailPOS.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Declare Public and private Data member
        public ObservableCollection<userDTO> lstUsers { get; private set; }
        public RelayCommand<userDTO> SelectUserCommand { get; private set; }
        public RelayCommand <object> LoginCommand { get; private set; }
        private string _userName;
        private string _uPassword;
        private bool _isEnabled;
        public string userName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged("userName");
            }
        }

        public string uPassword
        {
            get { return _uPassword; }
            set
            {
                _uPassword = value;
                RaisePropertyChanged("uPassword");
            }
        }

        public bool isEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged("isEnabled");
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            lstUsers = new ObservableCollection<userDTO>();
            FillUsers();
            SelectUserCommand = new RelayCommand<userDTO>(SelectedUserName);
            LoginCommand = new RelayCommand<object>(CheckUserExists);
           
        }       
        #endregion


        /// <summary>
        /// Checks the user exists.
        /// </summary>
        private void CheckUserExists(object obj)
        {
            var passwordBox = obj as PasswordBox;
            uPassword = passwordBox.Password;

            // to do check user
        }
       

        /// <summary>
        /// Selecteds the name of the user.
        /// </summary>
        /// <param name="userDT">The user DT.</param>
        private void SelectedUserName(userDTO userDT)
        {
            userName = userDT.UserName == "others" ? string.Empty : userDT.UserName;
            isEnabled = userDT.UserName == "others" ? true : false; 
              
        }

        /// <summary>
        /// Fills the users.
        /// </summary>
        private void FillUsers()
        {
            lstUsers.Add(new userDTO { UserId = 1, UserName = "mark taylor" });
            lstUsers.Add(new userDTO { UserId = 2, UserName = "Jim Taylor" });
            lstUsers.Add(new userDTO { UserId = 3, UserName = "Tom Hank" });
            lstUsers.Add(new userDTO { UserId = 4, UserName = "others" });
        }
       
    }

    public class userDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
