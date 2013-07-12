using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;

namespace RetailPOS.ViewModel.Settings
{
    public class PurchaseHistoryViewModel : ViewModelBase
    {
        #region Public and Private Data Members

        public ObservableCollection<PurchaseHistoryDTO> LstPurchaseHistory { get; private set; }

        private string _invoiceNo;
        private DateTime _selectedDate;

        #endregion

        #region Public Properties

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged("SelectedDate");
            }
        }

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set
            {
                _invoiceNo = value;
                RaisePropertyChanged("InvoiceNo");
            }
        }

        #endregion

        #region Constructor

        public PurchaseHistoryViewModel()
        {
            LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>();

            GetPurchaseHistoryDetails();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get Purchase history details from database
        /// </summary>
        private void GetPurchaseHistoryDetails()
        {
            LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in ServiceFactory.ServiceClient.GetPurchaseHistoryDetails()
                                                                              select item);

            if(!string.IsNullOrEmpty(InvoiceNo))
            {
                LstPurchaseHistory = new ObservableCollection<PurchaseHistoryDTO>(from item in LstPurchaseHistory
                                                                                  where item.Invoice_No == InvoiceNo
                                                                                  select item);
            }
        }

        #endregion
    }
}