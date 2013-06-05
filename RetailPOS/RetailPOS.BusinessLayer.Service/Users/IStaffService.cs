#region Using directives

using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects;

#endregion

namespace RetailPOS.BusinessLayer.Service.Users
{
    public interface IStaffService
    {
        /// <summary>
        /// Get list of active staff details
        /// </summary>
        /// <returns>returns list of active staff users</returns>
        IList<StaffDTO> GetStaffDetails();
    }
}