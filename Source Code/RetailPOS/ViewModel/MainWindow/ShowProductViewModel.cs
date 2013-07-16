using GalaSoft.MvvmLight;
using RetailPOS.Utility;
using RetailPOS.RetailPOSService;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RetailPOS.Core;
using System.Linq;

namespace RetailPOS.ViewModel.MainWindow
{
    public class ShowProductViewModel : ViewModelBase
    {
        #region Public and Private Data Member

        public IList<ProductDTO> LstProduct { get; private set; }

        private int _id;
        private string _name;
        private string _code;
        private decimal _price;
        private short _quantity;
        private string _description;

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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        public short Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");

                if (Quantity > 0)
                {
                    SelectedProduct.Quantity = Quantity;
                    Mediator.NotifyColleagues("SetSelectedProduct", SelectedProduct);
                }
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

        public ProductDTO SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        #endregion

        #region Constructor

        public ShowProductViewModel()
        {
            Mediator.Register("ShowProductDetails", ShowProductDetails);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
        private void GetCommonProducts()
        {
            LstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetCommonProduct()
                                                              select item);
        }

        private void ShowProductDetails(object selectedProduct)
        {
            SelectedProduct = (ProductDTO)selectedProduct;

            Id = SelectedProduct.Id;
            Name = SelectedProduct.Name;
            Code = SelectedProduct.BarCode;
            Price = SelectedProduct.Retail_Price.HasValue ? SelectedProduct.Retail_Price.Value : 0;
            SelectedProduct.Quantity = Quantity = 0;
            Description = SelectedProduct.Description;
        }

        #endregion
    }
}