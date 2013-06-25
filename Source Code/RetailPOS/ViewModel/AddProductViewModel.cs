using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using System.Linq;
using System;


namespace RetailPOS.ViewModel
{
    public class AddProductViewModel : ViewModelBase
    {
        #region Declare Public and private Data member
        public ObservableCollection<CStatusModel> lstStatus { get; private set; }
        private ObservableCollection<ProductCategoryDTO> _lstCategories;
        private CStatusModel _selectedStatus;  
        private ProductCategoryDTO _selectedCategory;
        private string _barCode;
        private string _productName;
        private string _productDescription;
        private decimal _retailPrice;
        private decimal _wholePrice;
        private decimal _taxRate;
        private bool _isWarranty;
        private decimal _size;
        private decimal _weight;
        private string _imagePath;

        public decimal RetailPrice
        {
            get
            {
                return _retailPrice;
            }
            set
            {
                _retailPrice = value;
                RaisePropertyChanged("RetailPrice");
            }
        }

        public decimal WholeSalePrice
        {
            get
            {
                return _wholePrice;
            }
            set
            {
                _wholePrice = value;
                RaisePropertyChanged("WholeSalePrice");
            }
        }

        public bool IsWarranty
        {
            get
            {
                return _isWarranty;
            }
            set
            {
                _isWarranty = value;
                RaisePropertyChanged("IsWarranty");
            }
        }

        public decimal Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                RaisePropertyChanged("Size");
            }
        }

        public decimal Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        public string ProductImage
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                RaisePropertyChanged("ProductImage");
            }
        }


        public CStatusModel SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public string ProductDescription
        {
            get
            {
                return _productDescription;
            }
            set
            {
                _productDescription = value;
                RaisePropertyChanged("ProductDescription");
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        public string BarCode
        {
            get
            {
                return _barCode;
            }
            set
            {
                _barCode = value;
                RaisePropertyChanged("BarCode");
            }
        }

        public ProductCategoryDTO SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }
        public ObservableCollection<ProductCategoryDTO> lstCategories
        {
            get { return _lstCategories; }
            set
            {
                _lstCategories = value;
                RaisePropertyChanged("lstCategories");
            }
        }

        #endregion

        public AddProductViewModel()
        {
            lstStatus = new ObservableCollection<CStatusModel>();
            lstCategories = new ObservableCollection<ProductCategoryDTO>();

            BindStatus();
        }

        private void BindStatus()
        {
            lstStatus.Add(new CStatusModel { StatusId = 0, StatusName = "Active" });
            lstStatus.Add(new CStatusModel { StatusId = 1, StatusName = "Deactive" });

        }

        private void AddCategories()
        {
            try
            {
                lstCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                             select item);
            }
            catch
            {
                throw;
            }
        }
    }

   
}
