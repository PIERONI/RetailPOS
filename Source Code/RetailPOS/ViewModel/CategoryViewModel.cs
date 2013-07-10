using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

namespace RetailPOS.ViewModel
{
    public class CategoryViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        private ObservableCollection<ProductCategoryDTO> _lstCategories;        
        private ObservableCollection<ProductDTO> _lstProduct;        

        public RelayCommand<ProductCategoryDTO> SelectProductCommand { get; private set; }
        private bool _firstPopupIsOpen;
        public  RelayCommand OpenFirstPopupCommand { get; private set; }
        private bool _OpenLooseCatPopupIsOpen;
        public RelayCommand OpenLooseCatPopupCommand { get; private set; }
        public RelayCommand RefershListBoxCommand { get; private set; }
        /// <summary>
        /// To open the product popup
        /// </summary>
        public RelayCommand<ProductDTO> ShowProduct { get; set; }

        private bool _IsProductPopupOpen;
        private ProductDTO _product;
        private ProductDTO _selectedProduct;


        private string _productName;
        private string _productCode;
        private decimal _productPrice;
        private int _productQuantity;
        private string _productDescription;
        private int _id;

       

        public ObservableCollection<ProductCategoryDTO> lstLooseCategories { get; private set; }

        public ObservableCollection<ProductCategoryDTO> lstCategories
        {
            get { return _lstCategories; }
            set
            {
                _lstCategories = value;
                RaisePropertyChanged("lstCategories");
            }
        }
        
        public ObservableCollection<ProductDTO> lstProduct
        {
            get { return _lstProduct; }
            set
            {
                _lstProduct = value;
                RaisePropertyChanged("lstProduct");
            }
        }

        public bool OpenLooseCatPopupIsOpen
        {
            get { return _OpenLooseCatPopupIsOpen; }
            set
            {
                _OpenLooseCatPopupIsOpen = value;
                RaisePropertyChanged("OpenLooseCatPopupIsOpen");
            }
        }

        public bool FirstPopupIsOpen
        {
            get { return _firstPopupIsOpen; }
            set
            {
                _firstPopupIsOpen = value;
                RaisePropertyChanged("FirstPopupIsOpen");
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
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

        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                _productCode = value;
                RaisePropertyChanged("ProductCode");
            }
        }

        public decimal ProductPrice
        {
            get { return _productPrice; }
            set
            {
                _productPrice = value;
                RaisePropertyChanged("ProductPrice");
            }
        }

        public int ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                _productQuantity = value;
                RaisePropertyChanged("ProductQuantity");

                if (ProductQuantity > 0)
                {
                    BindProduct();
                }
            }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set
            {
                _productDescription = value;
                RaisePropertyChanged("ProductDescription");
            }
        }


        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryViewModel"/> class.
        /// </summary>
        public CategoryViewModel()
        {           
            lstCategories = new ObservableCollection<ProductCategoryDTO>();
            lstLooseCategories = new ObservableCollection<ProductCategoryDTO>();
            lstProduct = new ObservableCollection<ProductDTO>();
            
            AddCategories();
            AddLooseCategories();
            FillCommonProducts();


            SelectProductCommand = new RelayCommand<ProductCategoryDTO>(FillProducts);
            OpenFirstPopupCommand = new RelayCommand(OpenFirstPopupClick);
            OpenLooseCatPopupCommand = new RelayCommand(OpenLooseCatPopupClick);
            RefershListBoxCommand = new RelayCommand(RefereshListBox);
            ShowProduct = new RelayCommand<ProductDTO>(OpenProductPopUp);
        }

        public ProductDTO Product
        {
            get { return _product; }
            set
            {
                _product = value;

                if (Product != null)
                {
                   //IsProductPopupOpen = true;
                    SelectedProduct = Product;
                }
            }
        }

        public ProductDTO SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;

                BindProduct();
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

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds the loose categories.
        /// </summary>
        private void AddLooseCategories()
        {
            lstLooseCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                         select item);
        }

        /// <summary>
        /// Refereshes the list box.
        /// </summary>
        private void RefereshListBox()
        {
            lstCategories.Clear();
            AddCategories();

        }

        /// <summary>
        /// Fills the products.
        /// </summary>
        /// <param name="productCategory">The product category.</param>
        private void FillProducts(ProductCategoryDTO productCategory)
        {
            lstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetProductByCategory(productCategory.Id)
                                                                         select item);
        }

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        private void FillCommonProducts()
        {
            lstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetCommonProduct() 
                                                                          select item);
        }

        /// <summary>
        /// Opens the first popup click.
        /// </summary>
        private void OpenFirstPopupClick()
        {
            FirstPopupIsOpen = true;
        }

        /// <summary>
        /// Opens the loose cat popup click.
        /// </summary>
        private void OpenLooseCatPopupClick()
        {
            OpenLooseCatPopupIsOpen = true;
        }

        /// <summary>
        /// Adds the categories.
        /// </summary>
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

        private void BindProduct()
        {
            Id = SelectedProduct.Id;
            ProductName = SelectedProduct.Name;
            ProductCode = SelectedProduct.BarCode;
            ProductPrice = SelectedProduct.Retail_Price.HasValue ? SelectedProduct.Retail_Price.Value : 0;
            SelectedProduct.Quantity = ProductQuantity;
            ProductDescription = SelectedProduct.Description;

           // Mediator.NotifyColleagues("SetSelectedProduct", SelectedProduct);
        }

        private void OpenProductPopUp(ProductDTO Product)
        {
           lstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetAllProducts()
                                                            select item);
            IsProductPopupOpen = true;

        }



        #endregion
    }
}