#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using RetailPOS.Constants;

#endregion

namespace RetailPOS.ViewModel.Settings
{
    public class SetAsideOrderViewModel : ViewModelBase
    {
        #region Declare Public and Private Memebers

        private IList<CustomerDTO> _LstCustomer;
        private IList<OrderMasterDTO> _lstOrder;

        /// <summary>
        /// To filter the datalist on searchbutton click
        /// </summary>
        public RelayCommand SearchOrderCommand { get; private set; }
        public RelayCommand CancelSearchOrderCommand { get; private set; }

        private string _name;
        private Nullable<DateTime> _selectedDate;
        
        #endregion

        #region Declare Public properties

        /// <summary>
        /// The list of customer
        /// </summary>
        public IList<CustomerDTO> LstCustomer
        {
            get { return _LstCustomer; }
            set
            {
                _LstCustomer = value;
                RaisePropertyChanged("LstCustomer");
            }
        }

        /// <summary>
        /// The list of Setaside order Detail from Order Master
        /// </summary>
        public IList<OrderMasterDTO> LstOrder
        {
            get { return _lstOrder; }
            set
            {
                _lstOrder = value;
                RaisePropertyChanged("LstOrder");
            }
        }

        /// <summary>
        /// Get/Set Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public Nullable<DateTime> SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged("SelectedDate");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SetAsideOrderViewModel"/> class.
        /// </summary>
        public SetAsideOrderViewModel()
        {
            LstCustomer = new List<CustomerDTO>();
            LstOrder = new ObservableCollection<OrderMasterDTO>();

            ////Get available order detail from database
            GetOrder();

            ////Get available customer from database
            GetCustomer();
            
            SearchOrderCommand = new RelayCommand(GetOrder);
            CancelSearchOrderCommand = new RelayCommand(ClearField);
        }

        #endregion

        #region Private Variables

        /// <summary>
        /// Get available customer from database
        /// </summary>
        private void GetCustomer()
        {
            LstCustomer = new List<CustomerDTO>(from item in ServiceFactory.ServiceClient.GetAllCustomers()
                                                select item).ToList();
        }

        /// <summary>
        /// Get available order detail from database
        /// </summary>
        private void GetOrder()
        {
            LstOrder = new ObservableCollection<OrderMasterDTO>(from item in ServiceFactory.ServiceClient.GetOrderItemByStatus((int)OrderStatus.SetAsideOrder)
                                                                select item).ToList();
            if (!string.IsNullOrEmpty(Name))
            {
                LstOrder = new ObservableCollection<OrderMasterDTO>(from item in LstOrder
                                                                    where item.CustomerName.ToLower().Contains(Name.ToLower())
                                                                    select item);
            }

            if (SelectedDate != null)
            {
                LstOrder = new ObservableCollection<OrderMasterDTO>(from item in LstOrder
                                                                    where item.Order_Date.Date == SelectedDate.Value.Date
                                                                    select item);
            }
        }

        /// <summary>
        /// To clear the field
        /// </summary>
        private void ClearField()
        {
            Name = string.Empty;
            SelectedDate = null;
            
            GetOrder();
        }

        #endregion
    }
}