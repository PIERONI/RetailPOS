using System.Collections.Generic;
using RetailPOS.CommonLayer.DataTransferObjects.User;

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService
    {
        /// <summary>
        /// Staff: This service implementation class is used to get staff details from repository
        /// </summary>
        /// <returns>return list of product by category</returns>
        /// <remarks></remarks>
        public IList<StaffDTO> GetStaffDetails()
        {
            return StaffService.GetStaffDetails();
        }
    }
}