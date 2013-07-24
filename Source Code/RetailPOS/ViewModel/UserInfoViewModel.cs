#region Using directives

using System;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;

#endregion

namespace RetailPOS.ViewModel
{
   public class UserInfoViewModel:ViewModelBase
   {
       #region Declare Public and Private Data member
       
       /// <summary>
       /// The _staff name
       /// </summary>
       private string _staffName;
       
       /// <summary>
       /// The _order no
       /// </summary>
       private int _orderNo;
       
       /// <summary>
       /// The _date time
       /// </summary>
       private string _dateTime;

       #endregion

       #region Public Properties

       /// <summary>
       /// Gets or sets the name of the staff.
       /// </summary>
       /// <value>
       /// The name of the staff.
       /// </value>
       public string StaffName
       {
           get { return _staffName; }
           set
           {
               _staffName = value;
               RaisePropertyChanged("StaffName");
           }
       }

       /// <summary>
       /// Gets or sets the order no.
       /// </summary>
       /// <value>
       /// The order no.
       /// </value>
       public int OrderNo
       {
           get { return _orderNo; }
           set
           {
               _orderNo = value;
               RaisePropertyChanged("OrderNo");
           }
       }

       /// <summary>
       /// Gets or sets the date time.
       /// </summary>
       /// <value>
       /// The date time.
       /// </value>
       public string DateTime
       {
           get { return _dateTime; }
           set
           {
               if (value != DateTime)
               {
                   _dateTime = value;
                   RaisePropertyChanged("DateTime");
               }               
           }
       }

       #endregion

       #region Declare Constructor

       public UserInfoViewModel()
       {
           BindValue();
       }

       #endregion

       #region Private Methods And Events

       /// <summary>
       /// Binds the value.
       /// </summary>
       private void BindValue()
       {
           this.DateTime = GetCurrentDateTime();
           OrderNo = 100;
           StaffName = "Naresh Phuloria";
       }

       /// <summary>
       /// Handles the Tick event of the dispatcherTimer control.
       /// </summary>
       /// <param name="sender">The source of the event.</param>
       /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
       private void dispatcherTimer_Tick(object sender, EventArgs e)
       {
           // Updating the Label which displays the current second
           this.DateTime = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToString(" HH:mm tt");

           // Forcing the CommandManager to raise the RequerySuggested event
           CommandManager.InvalidateRequerySuggested();
       }

       /// <summary>
       /// Gets the current date time.
       /// </summary>
       /// <returns></returns>
       public string GetCurrentDateTime()
       {
           try
           {
               DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
               dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
               dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
               dispatcherTimer.Start();
               return DateTime;
           }
           catch
           {
               throw;
           }
       }

       #endregion
   }
}