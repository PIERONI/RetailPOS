#region Using directives

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#endregion

namespace RetailPOS.ViewModel
{
    public class AddCategoryViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public RelayCommand SaveCategory { get; private set; }
        public RelayCommand CancelCategorySetting { get; private set; }

        private IList<ProductCategoryDTO> _lstSearchCategoryName { get; set; }

        /// <summary>
        /// The _staff name
        /// </summary>
        private string _name;

        /// <summary>
        /// The _order no
        /// </summary>
        private string _description;

        /// <summary>
        /// The _date time
        /// </summary>
        private string _selectedColor;

        /// <summary>
        /// The _sort order
        /// </summary>
        private int _sortOrder;
        private ProductCategoryDTO _categname;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets list of categories for search items
        /// </summary>
        /// <value>
        /// The list of categories.
        /// </value>
        public IList<ProductCategoryDTO> LstSearchCategoryName
        {
            get { return _lstSearchCategoryName; }
            set
            {
                _lstSearchCategoryName = value;
                RaisePropertyChanged("LstSearchCategoryName");
            }
        }

        /// <summary>
        /// Gets or sets name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
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
        /// Gets or sets the category description.
        /// </summary>
        /// <value>
        /// The category description.
        /// </value>
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the selected color.
        /// </summary>
        /// <value>
        /// The selected color.
        /// </value>
        public string SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                if (value != string.Empty)
                {
                    _selectedColor = value;
                    RaisePropertyChanged("SelectedColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder
        {
            get { return _sortOrder; }
            set
            {
                _sortOrder = value;
                RaisePropertyChanged("SortOrder");
            }
        }

        public ProductCategoryDTO SelectedCategoryName
        {
            get { return _categname; }
            set
            {
                _categname = value;
                RaisePropertyChanged("SelectedCategoryName");

                if (SelectedCategoryName != null)
                {
                    GetSearchAttributes(SelectedCategoryName.Name);
                    
                }
            }
        }

        #endregion

        #region Constructor

        public AddCategoryViewModel()
        {
            SaveCategory = new RelayCommand(SaveCategorySetting);
            CancelCategorySetting = new RelayCommand(CancelSetting);            
            LstSearchCategoryName=new List<ProductCategoryDTO>();
            GetSearchAttributes(string.Empty);  
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Save category deatils in database
        /// </summary>
        private void SaveCategorySetting()
        {
            var categoryDetails = InitializeCategoryDetails();
            ServiceFactory.ServiceClient.SaveCategoryDetails(categoryDetails);
        }

        /// <summary>
        /// Initializes Category details with values from controls
        /// </summary>
        /// <returns></returns>
        private ProductCategoryDTO InitializeCategoryDetails()
        {
            return new ProductCategoryDTO
            {
                Name = Name,
                Description = Description,
                Color = SelectedColor
            };
        }

        /// <summary>
        /// Cancels the current operation
        /// </summary>
        private void CancelSetting()
        {
            Name = string.Empty;
            GetSearchAttributes(string.Empty);  
            //AddCategoryViewModel viewModel = new AddCategoryViewModel();
        }

        /// <summary>
        /// Search the current operation
        /// </summary>
        private void GetSearchAttributes(string categoryName)
        {
            LstSearchCategoryName = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                      select item).ToList();
            LstSearchCategoryName = LstSearchCategoryName.Where(item => (categoryName == "" || categoryName == null ? item.Name == item.Name : item.Name == categoryName)).ToList();

            //if (!string.IsNullOrEmpty(categoryName))
            //{
            //    LstSearchCategoryName = LstSearchCategoryName.Where(item => item.Name.Contains(categoryName)).ToList();
            //}
        }

        #endregion
    }
}