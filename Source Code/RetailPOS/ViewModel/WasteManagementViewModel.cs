using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace RetailPOS.ViewModel
{
    public class WasteManagementViewModel : ViewModelBase
    {
        public WasteManagementViewModel()
        {
            ShowHideWeight = new RelayCommand(ShowWeight);
            HideWeighT = new RelayCommand(HideWeight);
            IsWeightVisible = Visibility.Collapsed;
        }

        #region Declare Public and Private Data member

        private Visibility _isWeightVisible;

         #endregion Public Properties

        #region Public Properties
        public RelayCommand ShowHideWeight { get; private set; }
        public RelayCommand HideWeighT { get; private set; }

        public Visibility IsWeightVisible
        {
            get
            {
                return _isWeightVisible;
            }
            set
            {
                _isWeightVisible = value;
                RaisePropertyChanged("IsWeightVisible");
            }
        }
       
        #endregion
        public void ShowWeight()
        {
            IsWeightVisible = Visibility.Visible;
        }

        public void HideWeight()
        {
            IsWeightVisible = Visibility.Hidden;
        }
    }
}
