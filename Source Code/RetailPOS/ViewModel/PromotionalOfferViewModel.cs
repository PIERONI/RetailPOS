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

        public IList<PromotionalOfferDTO> lstSearchPromotionalOffer { get; private set; }
       
        #endregion

        #region Declare Constructor

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