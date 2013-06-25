using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using RetailPOS.Utility;


namespace RetailPOS.ViewModel
{    
    public class RightPanelPaymentDetailViewModel : ViewModelBase
    {

        #region Declare Public and private Data member

        public IList<CustomerDTO> lstSearchCustomer { get; private set; }

        public RelayCommand OpenPayEntryBalancePopUp { get; private set; }
       
        // private ProductDTO _ShowPopup;
        private bool _IsProductPopupOpen;
        private string _customerBalance;

        private CustomerDTO _selectedCustomer;
        private CustomerDTO _customer;
        private Visibility _isVisibleCustomerInfo;
        private string _customerName;
        private string _customerName1;
        private string _Mobile;
        private string _Email;
        private string _Balance;
        
        #endregion

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

        public bool IsProductPopupOpen
        {
            get { return _IsProductPopupOpen; }
            set
            {
                
                _IsProductPopupOpen = value;
                RaisePropertyChanged("IsProductPopupOpen");
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

        public RightPanelPaymentDetailViewModel()
        {
            OpenPayEntryBalancePopUp = new RelayCommand(OpenProductPopupClick);
            lstSearchCustomer = new List<CustomerDTO>();

            lstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }

        private void OpenProductPopupClick()
        {
         
            IsProductPopupOpen = true;
            
                
            CustomerName = null;
            CustomerBalance = null;
            CustomerName1 = null;
            Mobile = null;
            Email = null;
            Balance = null;

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
    }
}