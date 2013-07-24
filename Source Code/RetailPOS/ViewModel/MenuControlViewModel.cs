#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using RetailPOS.Utility;
using System.Linq;

#endregion

namespace RetailPOS.ViewModel
{
    public class MenuControlViewModel : ViewModelBase
    {   
        #region Declare Public and Private Data member

        public RelayCommand OpenOrderPopupCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }
        public RelayCommand OpenSetAsideOrderPopUpCommand { get; private set; }
        public RelayCommand OpenOrdersInQueuePopUpCommand { get; private set; }

        private IList<CustomerDTO> _lstCustomer;
        private IList<OrderMasterDTO> _lstOrderMaster;

        private bool _isOrderPopUpOpen;
        private Visibility _isVisibleCustomerInfo;
        private bool _isSetAsideOrderPopUpOpen;
        private bool _isOrdersInQueuePopUpOpen;
        
        private string _customerName;
        private string _customerMobile;
        
        //private CustomerDTO _customer;       
        private CustomerDTO _selectedCustomer;
        private OrderMasterDTO _selectedOrder;
        
        #endregion      

        #region Constructor

        public MenuControlViewModel()
        {
            LstCustomer = new ObservableCollection<CustomerDTO>();

            Mediator.Register("CloseSetAsideOrderPopUpWindow", CloseAllPopUpWindow);
            Mediator.Register("CloseOrderInQueuePopUpWindow", CloseAllPopUpWindow);

            OpenOrderPopupCommand = new RelayCommand(OpenOrderPopup);
            OpenSetAsideOrderPopUpCommand = new RelayCommand(OpenSetAsideOrders);
            OpenOrdersInQueuePopUpCommand = new RelayCommand(OpenOrdersInQueue);
            ClearCommand = new RelayCommand(ClearControls);
        }

        #endregion

        #region Public Properties

        public IList<CustomerDTO> LstCustomer 
        {
            get { return _lstCustomer; }
            set
            {
                _lstCustomer = value;
                RaisePropertyChanged("LstCustomer");
            }
        }

        public IList<OrderMasterDTO> LstOrderMaster
        {
            get { return _lstOrderMaster; }
            set
            {
                _lstOrderMaster = value;
                RaisePropertyChanged("LstOrderMaster");
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

        public Visibility isVisibleCustomerInfo
        {
            get { return _isVisibleCustomerInfo; }
            set
            {
                _isVisibleCustomerInfo = value;
                RaisePropertyChanged("isVisibleCustomerInfo");
            }
        }

        public string CustomerMobile
        {
            get { return _customerMobile; }
            set
            {
                _customerMobile = value;
                RaisePropertyChanged("CustomerMobile");
            }
        }

        public CustomerDTO SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value != null)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged("SelectedCustomer");
                    BindCustomer();

                    Mediator.NotifyColleagues("SetSelectedCustomer", value);
                }
            }
        }

        public OrderMasterDTO SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                if (value != null)
                {
                    _selectedOrder = value;
                    RaisePropertyChanged("SelectedOrder");

                    Mediator.NotifyColleagues("SetSelectedOrder", value);
                }
            }
        }

        //public CustomerDTO Customer
        //{
        //    get { return _customer; }
        //    set
        //    {
        //        _customer = value;

        //        if (Customer == null)
        //        {
        //            SelectedCustomer = null;
        //        }

        //        if (SelectedCustomer == null && Customer != null)
        //        {
        //            SelectedCustomer = Customer;
        //        }
        //    }
        //}

        public bool IsOrderPopUpOpen
        {
            get { return _isOrderPopUpOpen; }
            set
            {
                _isOrderPopUpOpen = value;
                RaisePropertyChanged("IsOrderPopUpOpen");
            }
        }

        public bool IsSetAsidePopUpOpen
        {
            get { return _isSetAsideOrderPopUpOpen; }
            set
            {
                _isSetAsideOrderPopUpOpen = value;
                RaisePropertyChanged("IsSetAsidePopUpOpen");
            }
        }

        public bool IsOrdersInQueuePopUpOpen
        {
            get { return _isOrdersInQueuePopUpOpen; }
            set
            {
                _isOrdersInQueuePopUpOpen = value;
                RaisePropertyChanged("IsOrdersInQueuePopUpOpen");
            }
        }

        #endregion

        #region Private Methods

        private void CloseAllPopUpWindow(object args)
        {
            IsSetAsidePopUpOpen = false;
            IsOrderPopUpOpen = false;
            IsOrdersInQueuePopUpOpen = false;
        }

        /// <summary>
        /// Get all active customer details from database
        /// </summary>
        private void GetCustomerDetails()
        {
            LstCustomer = ServiceFactory.ServiceClient.GetAllCustomers();
        }

        private void OpenOrderPopup()
        {   
            IsOrdersInQueuePopUpOpen = false;
            IsSetAsidePopUpOpen = false;
            IsOrderPopUpOpen = true;

            ////Clear the controls
            ClearControls();
        }

        private void OpenSetAsideOrders()
        {
            ////Get all active customer details from database
            GetCustomerDetails();

            IsOrderPopUpOpen = false;
            IsOrdersInQueuePopUpOpen = false;
            IsSetAsidePopUpOpen = true;
            
            ////Clear the controls
            ClearControls();
        }

        private void OpenOrdersInQueue()
        {
            ////Get all active orders in queue from database
            GetOrdersInQueue();

            IsOrderPopUpOpen = false;
            IsSetAsidePopUpOpen = false;
            IsOrdersInQueuePopUpOpen = true;

            ////Clear the controls
            ClearControls();
        }

        private void GetOrdersInQueue()
        {
            LstOrderMaster = ServiceFactory.ServiceClient.GetOrdersInQueue();
        }

        private void BindCustomer()
        {
            if (SelectedCustomer == null)
            {
                isVisibleCustomerInfo = Visibility.Collapsed;
                return;
            }

            CustomerDTO selectedCustomer = SelectedCustomer;

            isVisibleCustomerInfo = Visibility.Visible;
            CustomerMobile = selectedCustomer.Mobile;
            CustomerName = selectedCustomer.First_Name + " " + selectedCustomer.Last_Name;
            isVisibleCustomerInfo = Visibility.Visible;
        }

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            CustomerName = string.Empty;
            CustomerMobile = string.Empty;
        }

        #endregion
    }
}