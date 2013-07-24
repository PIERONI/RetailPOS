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

namespace RetailPOS.ViewModel.Settings
{
    public class PromotionalOfferViewModel : ViewModelBase
    {
        #region Declare Public and Private Data member

        public IList<MeasureUnitDTO> LstMeasureUnit { get; private set; }
        
        public RelayCommand SavePromotionalOfferCommand { get; private set; }
        public RelayCommand CancelPromotionalOfferCommand { get; private set; }
        public RelayCommand SearchPromotionalOfferCommand { get; private set; }
        public RelayCommand CancelSearchPromotionalOfferCommand { get; private set; }

        private IList<PromotionalOfferDTO> _lstPromotionalOffer { get; set; }
        
        private Nullable<DateTime> _startDuration;
        private Nullable<DateTime> _endDuration;
        
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

        public Nullable<DateTime> StartDuration
        {
            get { return _startDuration; }
            set
            {
                _startDuration = value;
                RaisePropertyChanged("StartDuration");
            }
        }

        public Nullable<DateTime> EndDuration
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
            LstPromotionalOffer = new List<PromotionalOfferDTO>();
            LstMeasureUnit = new ObservableCollection<MeasureUnitDTO>();

            SavePromotionalOfferCommand = new RelayCommand(SavePromotionalOfferDetail);
            CancelPromotionalOfferCommand = new RelayCommand(CancelSetting);
            SearchPromotionalOfferCommand = new RelayCommand(SearchPromotionalOffer);
            CancelSearchPromotionalOfferCommand = new RelayCommand(CancelSearchPromotionalOffer);

            ////Get Promotional offer details from database
            GetPromotionalOfer();
            
            ////Get all active measure units from database
            GetMeasureUnit();

            ////Clear the controls
            ClearControls();
        }

        #endregion

        /// <summary>
        /// Search promotional offers from database
        /// </summary>
        private void SearchPromotionalOffer()
        {
            ////Get Promotional offer details from database
            GetPromotionalOfer();
        }

        private void CancelSearchPromotionalOffer()
        {
            ////Clear the controls
            ClearControls();

            ////Get Promotional offer details from database
            GetPromotionalOfer();
        }

        private void CancelSetting()
        {
            PromotionalOfferViewModel viewModel = new PromotionalOfferViewModel();
        }

        private void SavePromotionalOfferDetail()
        {
            var promotionalOfferDetail = InitializePromotionalOfferDetails();
            ServiceFactory.ServiceClient.SavePromotionalOffer(promotionalOfferDetail);

            ////Clear the controls
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

        /// <summary>
        /// Clear the controls
        /// </summary>
        private void ClearControls()
        {
            Name = string.Empty;
            Description = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Duration = 0;
            PurchaseQuantity = 0;
            SelectedMeasureUnitForPurchaseQuantity = null;
            SelectedMeasureUnitForOfferQuantity = null;
            OfferQuantity = 0;
            OfferPercentage = 0;
            StartDuration = null;
            EndDuration = null;
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
        private void  GetPromotionalOfer()
        {
            LstPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(from item in 
                ServiceFactory.ServiceClient.GetPromotionalOfferDetail()
                select new PromotionalOfferDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Start_Date = item.Start_Date,
                    End_Date = item.End_Date,
                    DateDuration = item.Start_Date.ToShortDateString() + " TO " + item.End_Date.ToShortDateString(),
                    PurchaseQuantityWithUnit = item.Purchase_Quantity.ToString() + " " + (item.Measure_Unit1 == null ? string.Empty : item.Measure_Unit1.Name),
                    OfferQuantityWithUnit = item.Offer_Quantity.ToString() + " " + (item.Measure_Unit == null ? string.Empty : item.Measure_Unit.Name),
                    Offer_Percentage = item.Offer_Percentage
                });

            if(!string.IsNullOrEmpty(Name))
            {
                LstPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(from item in LstPromotionalOffer
                                                                                    where item.Name.ToLower().Contains(Name.ToLower()) 
                                                                                    select item);
            }

            if (StartDuration != null && EndDuration != null)
            {
                LstPromotionalOffer = new ObservableCollection<PromotionalOfferDTO>(from item in LstPromotionalOffer
                                                                                    where item.Start_Date.Date >= StartDuration && item.End_Date.Date <= EndDuration
                                                                                    select item);
            }
        }
    }
}