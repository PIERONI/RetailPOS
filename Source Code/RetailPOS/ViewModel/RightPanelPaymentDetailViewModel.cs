#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

#endregion

namespace RetailPOS.ViewModel
{    
    public class RightPanelPaymentDetailViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public IList<CustomerDTO> lstSearchCustomer { get; private set; }
        public RelayCommand OpenPayEntryBalancePopUp { get; private set; }
        public RelayCommand OpenCardEntryBalancePopUp { get; private set; }
        public RelayCommand SelectCardCommand { get; private set; }
       
        private bool _isPaymentEntryPopupOpen;
        private bool _IsCardPopupOpen;
        
        private CustomerDTO _selectedCustomer;
        private CustomerDTO _customer;
        private Visibility _isVisibleCustomerInfo;

        private string _customerBalance;
        private string _customerName;
        private string _customerName1;
        private string _Mobile;
        private string _Email;
        private string _Balance;
        private int _CardAmount;
        private int _PaidAmount;
        
        #endregion

        #region Public Properties

        public string CustomerBalance
        {
            get
            {
                return _customerBalance;
            }
            set
            {
                _customerBalance = value;
                RaisePropertyChanged("CustomerBalance");
            }
        }

        public CustomerDTO SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                BindCustomer();
            }
        }

        public CustomerDTO Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;

                if (Customer == null)
                {
                    SelectedCustomer = null;
                }
                if (SelectedCustomer == null && Customer != null)
                {
                    SelectedCustomer = Customer;
                }
            }
        }

        public bool IsPaymentEntryPopupOpen
        {
            get { return _isPaymentEntryPopupOpen; }
            set
            {   
                _isPaymentEntryPopupOpen = value;
                RaisePropertyChanged("IsPaymentEntryPopupOpen");
            }
        }

        public bool IsCardPopupOpen
        {
            get { return _IsCardPopupOpen; }
            set
            {
                _IsCardPopupOpen = value;
                RaisePropertyChanged("IsCardPopupOpen");
            }
        }

        public Visibility isVisibleCustomerInfo
        {
            get
            {
                return _isVisibleCustomerInfo;
            }
            set
            {
                _isVisibleCustomerInfo = value;
                RaisePropertyChanged("isVisibleCustomerInfo");
            }
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                RaisePropertyChanged("CustomerName");
            }
        }

        public string CustomerName1
        {
            get { return _customerName1; }
            set
            {
                _customerName1 = value;
                RaisePropertyChanged("CustomerName1");
            }
        }

        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
                RaisePropertyChanged("Mobile");
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
                RaisePropertyChanged("Balance");
            }
        }

        public int CardAmount
        {
            get { return _CardAmount; }
            set
            {
                _CardAmount = value;
                RaisePropertyChanged("CardAmount");
            }
        }

        public int PaidAmount
        {
            get { return _PaidAmount; }
            set
            {
                _PaidAmount = value;
                RaisePropertyChanged("PaidAmount");
            }
        }

        #endregion

        #region Constructor

        public RightPanelPaymentDetailViewModel()
        {
            OpenPayEntryBalancePopUp = new RelayCommand(OpenPayEntryBalancePopUpClick);
            OpenCardEntryBalancePopUp = new RelayCommand(OpenCardPopupclick);
            SelectCardCommand = new RelayCommand(BindCardAmount);
            lstSearchCustomer = new List<CustomerDTO>();

            lstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }

        #endregion

        private void OpenPayEntryBalancePopUpClick()
        {
            IsPaymentEntryPopupOpen = true;           

            CustomerName = null;
            CustomerBalance = null;
            CustomerName1 = null;
            Mobile = null;
            Email = null;
            Balance = null;
        }

        private void OpenCardPopupclick()
        {
            IsCardPopupOpen = true;
        }

        /// <summary>
        /// Binds the customer.
        /// </summary>
        private void BindCustomer()
        {
            if (SelectedCustomer == null)
            {
                isVisibleCustomerInfo = Visibility.Collapsed;
                return;
            }

            isVisibleCustomerInfo = Visibility.Visible;
            CustomerName = SelectedCustomer.First_Name;
            CustomerBalance = SelectedCustomer.Credit_Limit.ToString();
            CustomerName1 = SelectedCustomer.First_Name + " " + SelectedCustomer.Last_Name;
            Mobile = SelectedCustomer.Mobile;
            Email = SelectedCustomer.Email;
            Balance = SelectedCustomer.Credit_Limit.ToString();
        }

        private void BindCardAmount()
        {
            PaidAmount = PaidAmount + CardAmount;
            IsCardPopupOpen = false;
            CardAmount = 0;
        }
    }
}