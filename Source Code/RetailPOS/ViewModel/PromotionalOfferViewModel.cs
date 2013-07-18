#region Using directives

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;
using GalaSoft.MvvmLight.Command;
using System;

#endregion

namespace RetailPOS.ViewModel
{
    public class PromotionalOfferViewModel : ViewModelBase
    {
        #region Declare Public and private Data member

        public IList<PromotionalOfferDTO> LstSearchPromotionalOffer { get; private set; }
        public IList<MeasureUnitDTO> LstMeasureUnit { get; private set; }
        
        public RelayCommand SavePromotionalOffer { get; private set; }
        public RelayCommand CancelPromotionalOfferSetting { get; private set; }
        public RelayCommand SearchPromotionalOffer { get; private set; }

        private IList<PromotionalOfferDTO> _lstPromotionalOffer { get; set; }
        
        private DateTime _startDuration;
        private DateTime _endDuration;

        private string _name;
        private string _description;
        private DateTime _startDate;
        private DateTime _endDate;
        private double _duration;
        private int _purchaseQuantity;
        private decimal _offerQuantity;
        private decimal _offerPercentage;
        private MeasureUnitDTO _selectedMeasureUnitForPurchaseQuantity;
        private MeasureUnitDTO _selectedMeasureUnitForOfferQuantity;

        #endregion

        #region Public Properties

        public IList<PromotionalOfferDTO> LstPromotionalOffer
        {
            get { return _lstPromotionalOffer; }
            set
            {
                _lstPromotionalOffer = value;
                RaisePropertyChanged("LstPromotionalOffer");
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

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChanged("EndDate");

                if (StartDate != (DateTime?)null)
                {
                    Duration = EndDate.Subtract(StartDate).TotalDays;
                }
            }
        }

        public DateTime StartDuration
        {
            get { return _startDuration; }
            set
            {
                _startDuration = value;
                RaisePropertyChanged("StartDuration");
            }
        }

        public DateTime EndDuration
        {
            get { return _endDuration; }
            set
            {
                _endDuration = value;
                RaisePropertyChanged("EndDuration");
            }
        }

        public double Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        public int PurchaseQuantity
        {
            get { return _purchaseQuantity; }
            set
            {
                _purchaseQuantity = value;
                RaisePropertyChanged("PurchaseQuantity");
            }
        }

        public decimal OfferQuantity
        {
            get { return _offerQuantity; }
            set
            {
                _offerQuantity = value;
                RaisePropertyChanged("OfferQuantity");
            }
        }

        public decimal OfferPercentage
        {
            get { return _offerPercentage; }
            set
            {
                _offerPercentage = value;
                RaisePropertyChanged("OfferPercentage");
            }
        }

        public MeasureUnitDTO SelectedMeasureUnitForPurchaseQuantity
        {
            get { return _selectedMeasureUnitForPurchaseQuantity; }
            set
            {
                _selectedMeasureUnitForPurchaseQuantity = value;
                RaisePropertyChanged("SelectedMeasureUnitForPurchaseQuantity");
            }
        }

        public MeasureUnitDTO SelectedMeasureUnitForOfferQuantity
        {
            get { return _selectedMeasureUnitForOfferQuantity; }
            set
            {
                _selectedMeasureUnitForOfferQuantity = value;
                RaisePropertyChanged("SelectedMeasureUnitForOfferQuantity");
            }
        }

        #endregion

        #region Declare Constructor

        public PromotionalOfferViewModel()
        {
            LstSearchPromotionalOffer = new List<PromotionalOfferDTO>();
            LstMeasureUnit = new ObservableCollection<MeasureUnitDTO>();

            SavePromotionalOffer = new RelayCommand(SavePromotionalOfferDetail);
            CancelPromotionalOfferSetting = new RelayCommand(CancelSetting);
            SearchPromotionalOffer = new RelayCommand(SearchDetails);

            ////Get Promotional offer details from database
            LstPromotionalOffer = GetPromotionalOfer();
            LstSearchPromotionalOffer = GetPromotionalOfer();

            ////Get all active measure units from database
            GetMeasureUnit();

            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        #endregion

        private void SearchDetails()
        {
            LstPromotionalOffer = GetPromotionalOfer();
        }

        private void CancelSetting()
        {
            PromotionalOfferViewModel viewModel = new PromotionalOfferViewModel();
        }

        private void SavePromotionalOfferDetail()
        {
            var promotionalOfferDetail = InitializePromotionalOfferDetails();
            ServiceFactory.ServiceClient.SavePromotionalOffer(promotionalOfferDetail);

            ClearControls();
        }

        private PromotionalOfferDTO InitializePromotionalOfferDetails()
        {
            return new PromotionalOfferDTO
            {
                Id = 0,
                Name = Name,
                Description = Description,
                Start_Date = StartDate,
                End_Date = EndDate,
                Purchase_Quantity = PurchaseQuantity,
                Pqty_Mu = SelectedMeasureUnitForPurchaseQuantity.Id,
                Offer_Quantity = OfferQuantity,
                Oqty_Mu = SelectedMeasureUnitForOfferQuantity.Id,
                Offer_Percentage = OfferPercentage
            };
        }

        private void ClearControls()
        {
            Name = string.Empty;
            Description = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Duration = 0;
            PurchaseQuantity = 0;
            SelectedMeasureUnitForPurchaseQuantity.Id = 0;
            SelectedMeasureUnitForOfferQuantity.Id = 0;
            OfferQuantity = 0;
            OfferPercentage = 0;
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
        private ObservableCollection<PromotionalOfferDTO>  GetPromotionalOfer()
        {
            ObservableCollection<PromotionalOfferDTO> lstPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(
                from item in ServiceFactory.ServiceClient.GetPromotionalOfferDetail()
                select new PromotionalOfferDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Start_Date = StartDate,
                    End_Date = EndDate,
                    DateDuration = item.Start_Date.ToShortDateString() + "TO" + item.End_Date.ToShortDateString(),
                    PurchaseQuantityWithUnit = item.Purchase_Quantity.ToString() + " " + (item.Measure_Unit1 == null ? string.Empty : item.Measure_Unit1.Name),
                    OfferQuantityWithUnit = item.Offer_Quantity.ToString() + " " + (item.Measure_Unit == null ? string.Empty : item.Measure_Unit.Name),
                    Offer_Percentage = item.Offer_Percentage
                });

            if(!string.IsNullOrEmpty(Name))
            {
                lstPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(from item in lstPromotionalOffer
                                                                                    where item.Name.ToLower().Contains(Name.ToLower())
                                                                                    select item);
            }
            return lstPromotionalOffer;
        }
    }
}