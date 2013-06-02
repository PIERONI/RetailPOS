using System.Linq;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using RetailPOS.CommonLayer.DataTransferObjects;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel
{
    public class CategoryViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public ObservableCollection<ProductCategoryDTO> lstCategories { get; private set; }
        public ObservableCollection<ProductDTO> _lstProduct;        
        public RelayCommand<ProductCategoryDTO> SelectProductCommand { get; private set; }
        
        public ObservableCollection<ProductDTO> lstProduct
        {
            get { return _lstProduct; }
            set
            {
                _lstProduct = value;
                RaisePropertyChanged("lstProduct");
            }
        }

        #endregion

        #region Constructor

        public CategoryViewModel()
        {
            lstCategories = new ObservableCollection<ProductCategoryDTO>();            
            AddCategories();            
            SelectProductCommand = new RelayCommand<ProductCategoryDTO>(FillProducts);
        }

        #endregion

        #region Private Methods

        private void FillProducts(ProductCategoryDTO productCategory)
        {
            RetailPOSService.RetailPOSServiceContractClient serviceClient = new RetailPOSService.RetailPOSServiceContractClient();
            lstProduct = new ObservableCollection<ProductDTO>(from item in serviceClient.GetProductByCategory(productCategory.Id)
                                                                         select item);
        }

        private void AddCategories()
        {
            try
            {
                RetailPOSService.RetailPOSServiceContractClient serviceClient = new RetailPOSService.RetailPOSServiceContractClient();
                lstCategories = new ObservableCollection<ProductCategoryDTO>(from item in serviceClient.GetCategories()
                                                                             select item);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}