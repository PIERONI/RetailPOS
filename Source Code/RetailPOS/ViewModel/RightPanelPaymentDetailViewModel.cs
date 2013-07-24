#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System;

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
        public RelayCommand UpdateCustomerPaymentDetail { get; private set; }
       
        private bool _isPaymentEntryPopupOpen;
        private bool _IsCardPopupOpen;
        
        private CustomerDTO _selectedCustomer;
        private CustomerDTO _customer;
        private Visibility _isVisibleCustomerInfo;

        private decimal _customerBalance;
        private string _customerName;
        private string _customerName1;
        private string _firstName;
        private string _Mobile;
        private string _Email;   
        private int _CardAmount;
        private decimal _PaidAmount;
        private int _Id;
        private decimal _creditLimit;
        private decimal _amountToPay;
        private decimal _amountPaid;
        
        #endregion

        #region Public Properties

        public decimal AmountToPay
        {
            get { return _amountToPay; }
            set
            {
                _amountToPay = value;
                RaisePropertyChanged("AmountToPay");
            }
        }

        public decimal CustomerBalance
        {
            get { return _customerBalance; }
            set
            {
                _customerBalance = value;
                RaisePropertyChanged("CustomerBalance");
            }
        }

        public CustomerDTO SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                BindCustomer();
            }
        }

        public CustomerDTO Customer
        {
            get { return _customer; }
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
            get { return _isVisibleCustomerInfo; }
            set
            {
                _isVisibleCustomerInfo = value;
                RaisePropertyChanged("isVisibleCustomerInfo");
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
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

        public string First_Name
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged("First_Name");
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

        public int CardAmount
        {
            get { return _CardAmount; }
            set
            {
                _CardAmount = value;
                RaisePropertyChanged("CardAmount");
            }
        }

        public decimal PaidAmount
        {
            get { return _PaidAmount; }
            set
            {
                _PaidAmount = value;
                RaisePropertyChanged("PaidAmount");
            }
        }

        public decimal AmountPaid
        {
            get { return _amountPaid; }
            set
            {
                _amountPaid = value;
                RaisePropertyChanged("AmountPaid");
            }
        }

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public decimal CreditLimit
        {
            get { return _creditLimit; }
            set
            {
                _creditLimit = value;
                RaisePropertyChanged("CreditLimit");
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
            UpdateCustomerPaymentDetail = new RelayCommand(UpdateCustomerBalanceDetail);
        }

        #endregion

        private void OpenPayEntryBalancePopUpClick()
        {
            IsPaymentEntryPopupOpen = true;           

            CustomerName = string.Empty;
            CustomerBalance = 0;
            CustomerName1 = string.Empty;
            Mobile = string.Empty;
            Email = string.Empty;
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
            Id = SelectedCustomer.Id;
            CustomerName = SelectedCustomer.First_Name;
            CustomerBalance =  SelectedCustomer.Balance;
            CustomerName1 = SelectedCustomer.First_Name + " " + SelectedCustomer.Last_Name;
            CreditLimit = SelectedCustomer.Credit_Limit;            
            Mobile = SelectedCustomer.Mobile;
            Email = SelectedCustomer.Email;           
        }

        private void BindCardAmount()
        {
            PaidAmount = PaidAmount + CardAmount;
            IsCardPopupOpen = false;
            CardAmount = 0;
        }

        private void UpdateCustomerBalanceDetail()
        {
            var updatecustomerdetail = InitializeCustomerPaymentDetail();
            ServiceFactory.ServiceClient.UpdateCustomerDetail(updatecustomerdetail);
            IsPaymentEntryPopupOpen = false;
            CancelPaymentEntryField();

        }

        private CustomerDTO InitializeCustomerPaymentDetail()
        {
            SelectedCustomer.Balance = CustomerBalance - AmountPaid;
            return SelectedCustomer;
        }
        /// <summary>
        /// To clear the payment entry field
        /// </summary>
        private void CancelPaymentEntryField()
        {
            Id = 0;
            CustomerName1 = string.Empty;
            Mobile = string.Empty;
            Email = string.Empty;
            CreditLimit = 0;
            AmountPaid = 0;
            First_Name = string.Empty;
        }
    }
}