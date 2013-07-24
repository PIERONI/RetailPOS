#region Using directives

using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using RetailPOS.Constants;

#endregion

namespace RetailPOS.ViewModel.Settings
{
    public class AddProductViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public ObservableCollection<ProductStatusDTO> LstStatus { get; private set; }
        public ObservableCollection<ProductCategoryDTO> LstCategories { get; private set; }

        public RelayCommand SaveProductCommand { get; set; }
        public RelayCommand CancelProductCommand { get; set; }
        public RelayCommand SearchProductCommand { get; set; }
        public RelayCommand CancelSearchCommand { get; set; }
        public RelayCommand GenerateBarCodeCommand { get; private set; }
        
        private ProductCategoryDTO _selectedCategory;
        private IList<ProductDTO> _lstProducts;
        private string _barCode;
        private string _productName;
        private string _description;
        private ProductStatusDTO _selectedStatus;
        private decimal _retailPrice;
        private decimal _wholePrice;
        private decimal _purchasePrice;
        private decimal _taxRate;
        private bool _hasWarranty;
        private bool _isProductSoldLoose;
        private Visibility _setVisibilityForLooseItems;
        private decimal _size;
        private decimal _weight;
        private string _imagePath;
        private string _name;

        private ProductDTO _selectedProduct;

        #endregion

        #region Public Properties

        public ProductCategoryDTO SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
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

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public ProductStatusDTO SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public decimal RetailPrice
        {
            get { return _retailPrice; }
            set
            {
                _retailPrice = value;
                RaisePropertyChanged("RetailPrice");
            }
        }

        public decimal WholeSalePrice
        {
            get { return _wholePrice; }
            set
            {
                _wholePrice = value;
                RaisePropertyChanged("WholeSalePrice");
            }
        }

        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                _purchasePrice = value;
                RaisePropertyChanged("PurchasePrice");
            }
        }

        public decimal TaxRate
        {
            get { return _taxRate; }
            set
            {
                _taxRate = value;
                RaisePropertyChanged("TaxRate");
            }
        }

        public bool HasWarranty
        {
            get { return _hasWarranty; }
            set
            {
                _hasWarranty = value;
                RaisePropertyChanged("HasWarranty");
            }
        }

        public Visibility SetVisibilityForLooseItems
        {
            get { return _setVisibilityForLooseItems; }
            set
            {
                _setVisibilityForLooseItems = value;
                RaisePropertyChanged("SetVisibilityForLooseItems");
            }
        }

        public bool IsProductSoldLoose
        {
            get { return _isProductSoldLoose; }
            set
            {
                _isProductSoldLoose = value;
                RaisePropertyChanged("IsProductSoldLoose");

                if (IsProductSoldLoose)
                {
                    SetVisibilityForLooseItems = Visibility.Visible;
                }
                else
                {
                    ////Hide attributes for all the items sold in loose quantity
                    HideAttributesForLooseItems();
                }
            }
        }

        public decimal Size
        {
            get { return _size; }
            set
            {
                _size = value;
                RaisePropertyChanged("Size");
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

        public string ProductImage
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                RaisePropertyChanged("ProductImage");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Search for product by product name
        /// </summary>
        ///<value>
        ///Returns product detail
        /// </value>
        public IList<ProductDTO> LstProducts
        {
            get { return _lstProducts; }
            set
            {
                _lstProducts = value;
                RaisePropertyChanged("LstProducts");
            }
        }
        
        #endregion

        #region Public Constructor

        public AddProductViewModel()
        {
            LstStatus = new ObservableCollection<ProductStatusDTO>();
            LstCategories = new ObservableCollection<ProductCategoryDTO>();

            ////Hide attributes for all the items sold in loose quantity
            ////This is default setting, which will be overriden once
            ////user checks the checkbox on screen.
            HideAttributesForLooseItems();

            ////Get Product status from database
            GetProductStatus();

            ////Get all active Product categories from database
            GetCategories();

            SaveProductCommand = new RelayCommand(SaveProductSetting);
            CancelProductCommand = new RelayCommand(CancelSetting);
            SearchProductCommand = new RelayCommand(SearchProducts);
            CancelSearchCommand = new RelayCommand(CancelSearch);
            GenerateBarCodeCommand = new RelayCommand(GenerateBarCode);

            LstProducts = new List<ProductDTO>();

            ///Get all products
            GetProducts(string.Empty);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generates the bar code.
        /// </summary>
        private void GenerateBarCode()
        {
            BarCode = AppConstants.COUNTRY_CODE + AppConstants.MANUFACTURER_CODE;
        }

        private void SearchProducts()
        {
            GetProducts(Name);
        }

        private void SaveProductSetting()
        {
            var productDetails = InitializeProductDetails();
            ServiceFactory.ServiceClient.SaveProductDetails(productDetails);

            ////Get all product by name
            GetProducts(string.Empty);

            ////Clear the controls
            ClearControls();
        }

        private ProductDTO InitializeProductDetails()
        {
            return new ProductDTO
            {
                Category_Id = SelectedCategory.Id,
                BarCode = BarCode,
                Name = ProductName,
                Description = Description,
                Status_Id = SelectedStatus.Id,
                Retail_Price = RetailPrice,
                Wholesale_Price = WholeSalePrice,
                PurchasePrice = PurchasePrice,
                Tax_Rate = TaxRate,
                Has_Warranty = HasWarranty,
                Size = Size,
                Weight = Weight,
                Image_Path = "Test"
            };
        }

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            SelectedCategory = null;
            BarCode = string.Empty;
            ProductName = string.Empty;
            Description = string.Empty;
            SelectedStatus = null;
            RetailPrice = 0;
            WholeSalePrice = 0;
            PurchasePrice = 0;
            TaxRate = 0;
            HasWarranty = false;
            IsProductSoldLoose = false;
            Size = 0;
            Weight = 0;
        }
        
        private void CancelSetting()
        {
            AddProductViewModel viewModel = new AddProductViewModel();
        }

        /// <summary>
        /// Hide attributes for all the items sold in loose quantity
        /// </summary>
        private void HideAttributesForLooseItems()
        {
            SetVisibilityForLooseItems = Visibility.Hidden;
        }

        /// <summary>
        ///Get Product status from database
        /// </summary>
        private void GetProductStatus()
        {
            LstStatus = new ObservableCollection<ProductStatusDTO>(from item in ServiceFactory.ServiceClient.GetProductStatus()
                                                                   select item);
        }

        /// <summary>
        /// Get all active Product Categories from database
        /// </summary>
        private void GetCategories()
        {
            LstCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                         select item);
        }

        /// <summary>
        /// Get all product by name
        /// </summary>
        /// <param name="productName"></param>
        private void GetProducts(string productName)
        {
            LstProducts = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetAllProducts()
                                                                     select item).ToList();

            if (!string.IsNullOrEmpty(productName))
            {
                LstProducts = LstProducts.Where(item => item.Name.Contains(productName)).ToList();
            }
        }

        private void CancelSearch()
        {
            Name = string.Empty;
            GetProducts(string.Empty);
        }

        #endregion
    }
}