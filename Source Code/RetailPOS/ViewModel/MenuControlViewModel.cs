using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RetailPOS.RetailPOSService;
using System.Linq;
using System.Windows;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;

namespace RetailPOS.ViewModel
{
    public class MenuControlViewModel : ViewModelBase
    {
        public MenuControlViewModel()
        {
            OpenOrderPopup = new RelayCommand(OpeOrderPopup);
            OpenSetAsideOrderPopup = new RelayCommand(OpenSetAsideOrderpopup);
            lstSearchCustomer = new List<CustomerDTO>();
            lstSearchCustomer = new ObservableCollection<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                                      select item).ToList();
        }

        public IList<CustomerDTO> lstSearchCustomer { get; private set; }
        public RelayCommand OpenOrderPopup { get; private set; }
        public RelayCommand OpenSetAsideOrderPopup { get; private set; }
        private bool _IsOrderPopupOpen;
        private Visibility _isVisibleCustomerInfo;
        private string _Mobile;
        private bool _IsSetAsideOrderPopupOpen;
        private CustomerDTO _customer;
        private CustomerDTO _selectedCustomer;
        private string _customerName1;
        private string _customerName;

        public string CustomerName1
        {
            get { return _customerName1; }
            set
            {
                _customerName1 = value;
                RaisePropertyChanged("CustomerName1");
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

        public bool IsOrderPopupOpen
        {
            get { return _IsOrderPopupOpen; }
            set
            {
                _IsOrderPopupOpen = value;
                RaisePropertyChanged("IsOrderPopupOpen");
            }
        }

        public bool IsSetAsidePopupOpen
        {
            get { return _IsSetAsideOrderPopupOpen; }
            set
            {
                _IsSetAsideOrderPopupOpen = value;
                RaisePropertyChanged("IsSetAsidePopupOpen");
            }
        }
        private void OpeOrderPopup()
        {
            IsOrderPopupOpen=true;
        }
        private void OpenSetAsideOrderpopup()
        {
            IsOrderPopupOpen = false;
            IsSetAsidePopupOpen = true;
            Mobile = null;
            CustomerName = null;
        }

        private void BindCustomer()
        {
            if (SelectedCustomer == null)
            {
                isVisibleCustomerInfo = Visibility.Collapsed;
                return;
            }
            isVisibleCustomerInfo = Visibility.Visible;
            Mobile = SelectedCustomer.Mobile;
            CustomerName = SelectedCustomer.First_Name;
            //CustomerName1 = SelectedCustomer.First_Name + " " + SelectedCustomer.Last_Name;
        }   
    }
}