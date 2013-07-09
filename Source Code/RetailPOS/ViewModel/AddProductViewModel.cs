#region Using directives

using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

#endregion

namespace RetailPOS.ViewModel
{
    public class AddProductViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public ObservableCollection<ProductStatusDTO> LstStatus { get; private set; }
        public ObservableCollection<ProductCategoryDTO> LstCategories { get; private set; }

        public RelayCommand SaveProduct { get; set; }
        public RelayCommand CancelProductSetting { get; set; }
        public RelayCommand CancelProduct { get; set; }
        
        private ProductCategoryDTO _selectedCategory;
        private IList<ProductDTO> _lstSearchProduct;
        private string _barCode;
        private string _name;
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
        private ProductDTO _productName;

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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
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

        /// <summary>
        /// binding the datagrid after produc selectiont
        /// </summary>
        ///<value>
        ///Returns product detail
        /// </value>
        public ProductDTO SelectProductSetail
        {

            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged("SelectProductSetail");

                if (SelectProductSetail != null)
                {

                    GetProducts(SelectProductSetail.Name);

                }
            }
        }
        /// <summary>
        /// Search for product by product name
        /// </summary>
        ///<value>
        ///Returns product detail
        /// </value>
        public IList<ProductDTO> SearchProductList
        {
            get { return _lstSearchProduct; }
            set
            {
                _lstSearchProduct = value;
                RaisePropertyChanged("SearchProductList");
            }
        }

        public ProductDTO SelectedProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged("SelectedProductName");
                if (SelectedProductName != null)
                {
                    GetProducts(SelectedProductName.Name);
                }
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

            SaveProduct = new RelayCommand(SaveProductSetting);
            CancelProductSetting = new RelayCommand(CancelSetting);
            ///Get all products
            SearchProductList = new List<ProductDTO>();
            GetProducts(string.Empty);
            CancelProduct = new RelayCommand(CamcelProducts);
        }

        #endregion

        #region Private Methods

        private void SaveProductSetting()
        {
            var productDetails = InitializeProductDetails();
            ServiceFactory.ServiceClient.SaveProductDetails(productDetails);
        }

        private ProductDTO InitializeProductDetails()
        {
            return new ProductDTO
            {
                Category_Id = SelectedCategory.Id,
                BarCode = BarCode,
                Name = Name,
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

        ///Get all product by name
        private void GetProducts(string productName)
        {
            SearchProductList = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetAllProducts()
                                                                     select item).ToList();
            SearchProductList = SearchProductList.Where(item => (productName == "" || productName == null ? item.Name == item.Name : item.Name == productName)).ToList();

        }

        private void CamcelProducts()
        {
            {
                Name = string.Empty;
                GetProducts(string.Empty);
                //AddCategoryViewModel viewModel = new AddCategoryViewModel();
            }
        }

        #endregion
    }
}