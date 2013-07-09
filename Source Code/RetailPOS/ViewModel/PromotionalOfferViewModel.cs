#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

#endregion

namespace RetailPOS.ViewModel
{
    public class PromotionalOfferViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public IList<PromotionalOfferDTO> LstSearchPromotionalOffer { get; private set; }
        public IList<MeasureUnitDTO> LstMeasureUnit { get; private set; }
        public IList<ProductCategoryDTO> LstCategories { get; private set; }

        private ProductCategoryDTO _selectedCategory;

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

        #endregion

        #region Declare Constructor

        public PromotionalOfferViewModel()
        {
            LstSearchPromotionalOffer = new List<PromotionalOfferDTO>();
            LstCategories = new ObservableCollection<ProductCategoryDTO>();
            LstMeasureUnit = new ObservableCollection<MeasureUnitDTO>();
            
            GetPromotionalOfer();

            ////Get all active Product categories from database
            GetCategories();
        }

        #endregion

        /// <summary>
        /// Get all active Product Categories from database
        /// </summary>
        private void GetCategories()
        {
            LstCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                         select item);
        }

        /// <summary>
        /// Get all active measure units from database
        /// </summary>
        private void GetMeasureUnit()
        {
            LstMeasureUnit = new ObservableCollection<MeasureUnitDTO>(from item in ServiceFactory.ServiceClient.GetMeasureUnitDetails()
                                                                         select item);
        }

        /// <summary>
        /// Get Promotional offer details from database
        /// </summary>
        private void GetPromotionalOfer()
        {
            LstSearchPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(from item in ServiceFactory.ServiceClient.GetPromotionalOfferDetail()
                                                                                      select item).ToList();
        }
    }
}