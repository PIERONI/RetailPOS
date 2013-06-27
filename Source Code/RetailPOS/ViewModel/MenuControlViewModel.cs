using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel
{
    public class MenuControlViewModel : ViewModelBase
    {
        public MenuControlViewModel()
        {
            OpenOrderPopup = new RelayCommand(OpeOrderPopup);
            OpenSetAsideOrderPopup = new RelayCommand(OpenSetAsideOrderpopup);
        }
        public RelayCommand OpenOrderPopup { get; private set; }
        public RelayCommand OpenSetAsideOrderPopup { get; private set; }
        private bool _IsOrderPopupOpen;
        private bool _IsSetAsideOrderPopupOpen;

        public bool IsOrderPopupOpen
        {
            get { return _IsOrderPopupOpen; }
            set
            {
                _IsOrderPopupOpen = value;
                RaisePropertyChanged("IsOrderPopupOpen");
            }
        }

        public bool IsSetAsidePopupOpen
        {
            get { return _IsSetAsideOrderPopupOpen; }
            set
            {
                _IsSetAsideOrderPopupOpen = value;
                RaisePropertyChanged("IsSetAsidePopupOpen");
            }
        }
        private void OpeOrderPopup()
        {
            IsOrderPopupOpen=true;
        }
        private void OpenSetAsideOrderpopup()
        {
            IsOrderPopupOpen = false;
            IsSetAsidePopupOpen = true;
        }
            
    }
}
