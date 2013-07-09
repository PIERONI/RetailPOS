#region Using directives

using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

#endregion

namespace RetailPOS.ViewModel
{
    public class WasteManagementViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public RelayCommand SetWeightToVisibile { get; private set; }
        public RelayCommand SetWeightToInVisibile { get; private set; }
        public RelayCommand SaveWasteManagement { get; private set; }
        public RelayCommand CancelWasteManagement { get; private set; }

        private Visibility _isWeightVisible;
        private string _productName;
        private string _barCode;
        private decimal _weight;
        private int _quantity;
        private int _productId;

        #endregion

        #region Public Properties

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        public string BarCode
        {
            get { return _barCode; }
            set
            {
                _barCode = value;
                RaisePropertyChanged("BarCode");
            }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                RaisePropertyChanged("ProductId");
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        public decimal Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        public Visibility IsWeightVisible
        {
            get { return _isWeightVisible; }
            set
            {
                _isWeightVisible = value;
                RaisePropertyChanged("IsWeightVisible");
            }
        }

        #endregion
        
        #region Constructor

        public WasteManagementViewModel()
        {
            SetWeightToVisibile = new RelayCommand(ShowWeight);
            SetWeightToInVisibile = new RelayCommand(HideWeight);
            SaveWasteManagement = new RelayCommand(SaveWasteManagementSetting);
            CancelWasteManagement = new RelayCommand(CancelSetting);

            HideWeight();
        }

        #endregion

        private void CancelSetting()
        {
            WasteManagementViewModel viewModel = new WasteManagementViewModel();
        }

        private void SaveWasteManagementSetting()
        {
            var wasteManagementDetails = InitializeWasteManagementDetails();
            ServiceFactory.ServiceClient.SaveWasteManagement(wasteManagementDetails);

            ClearControls();
        }

        private WasteManagementDTO InitializeWasteManagementDetails()
        {
            return new WasteManagementDTO
            {
                Id = 0,
                ProductId = 1,
                Quantity = Quantity,
                Weight = Weight
            };
        }

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            Quantity = 0;
            Weight = 0;
            BarCode = string.Empty;
            ProductName = string.Empty;
        }

        private void ShowWeight()
        {
            IsWeightVisible = Visibility.Visible;
        }

        private void HideWeight()
        {
            IsWeightVisible = Visibility.Hidden;
        }
    }
}