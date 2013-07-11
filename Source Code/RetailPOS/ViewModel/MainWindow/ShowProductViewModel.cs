using GalaSoft.MvvmLight;
using RetailPOS.Utility;
using RetailPOS.RetailPOSService;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel.MainWindow
{
    public class ShowProductViewModel : ViewModelBase
    {
        #region Public and Private Data Member

        private int _id;
        private string _productName;
        private string _productCode;
        private decimal _productPrice;
        private int _productQuantity;
        private string _productDescription;

        private ProductDTO _selectedProduct;

        #endregion

        #region Public Properties

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
                    SelectedProduct.Quantity = ProductQuantity;
                    Mediator.NotifyColleagues("SetSelectedProduct", SelectedProduct);
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

        public ProductDTO SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");

                BindProduct();
            }
        }

        #endregion

        #region Private Methods

        private void BindProduct()
        {
            Id = SelectedProduct.Id;
            ProductName = SelectedProduct.Name;
            ProductCode = SelectedProduct.BarCode;
            ProductPrice = SelectedProduct.Retail_Price.HasValue ? SelectedProduct.Retail_Price.Value : 0;
            SelectedProduct.Quantity = ProductQuantity = 0;
            ProductDescription = SelectedProduct.Description;
        }

        #endregion
    }
}