#region Using directives

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.RetailPOSService;
using RetailPOS.Core;

#endregion

namespace RetailPOS.ViewModel
{
    public class AddCategoryViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public RelayCommand SaveCategory { get; private set; }
        public RelayCommand CancelCategorySetting { get; private set; }

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

        #endregion

        #region Public Properties

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

        #endregion

        #region Constructor

        public AddCategoryViewModel()
        {
            SaveCategory = new RelayCommand(SaveCategorySetting);
            CancelCategorySetting = new RelayCommand(CancelSetting);
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
            AddCategoryViewModel viewModel = new AddCategoryViewModel();
        }

        #endregion
    }
}