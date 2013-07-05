using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetailPOS.RetailPOSService;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using RetailPOS.Core;

namespace RetailPOS.ViewModel
{
    public class PromotionalOfferViewModel : ViewModelBase
    {
        #region Declare Public and private Data member
        public IList<PromotionalOfferDTO> lstSearchPromotionalOffer { get; private set; }
       
        #endregion

        #region DeclareCunstructor
        public PromotionalOfferViewModel()
        {
            lstSearchPromotionalOffer = new List<PromotionalOfferDTO>();
            GetPromotionalOfer();
        }
        #endregion

        private void GetPromotionalOfer()
        {
            lstSearchPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(from item in ServiceFactory.ServiceClient.GetPromotionalOfferDetail()
                                                                                      select item).ToList();
        }

    }
}
