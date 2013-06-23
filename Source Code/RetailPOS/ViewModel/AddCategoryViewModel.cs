using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace RetailPOS.ViewModel
{
    class AddCategoryViewModel : ViewModelBase
    {
        /// <summary>
        /// The _staff name
        /// </summary>
        private string _categoryName;

        /// <summary>
        /// The _order no
        /// </summary>
        private string _categoryDescription;

        /// <summary>
        /// The _date time
        /// </summary>
        private string _selectedColor;


        /// <summary>
        /// The _sort order
        /// </summary>
        private int _sortOrder;


        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                RaisePropertyChanged("CategoryName");
            }
        }


        /// <summary>
        /// Gets or sets the category description.
        /// </summary>
        /// <value>
        /// The category description.
        /// </value>
        public string CategoryDescription
        {
            get { return _categoryDescription; }
            set
            {
                _categoryDescription = value;
                RaisePropertyChanged("CategoryDescription");
            }
        }


        /// <summary>
        /// Gets or sets the color of the selected.
        /// </summary>
        /// <value>
        /// The color of the selected.
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


        public AddCategoryViewModel()
        {

        }
    }
}
