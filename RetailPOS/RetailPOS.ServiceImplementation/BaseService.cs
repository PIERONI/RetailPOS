#region Using directives

using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.ServiceImplementation.ServiceContracts;

#endregion

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService : IRetailPOSServiceContract
    {
        /// <summary>
        /// Gets or sets the category service.
        /// </summary>
        /// <value>
        /// The category service.
        /// </value>
        public ICategoryService CategoryService { get; set; }

        /// <summary>
        /// Gets or sets the category service.
        /// </summary>
        /// <value>
        /// The category service.
        /// </value>
        public IProductService ProductService { get; set; }

        /// <summary>
        /// Gets or sets the master service.
        /// </summary>
        /// <value>
        /// The master service.
        /// </value>
        public IMasterService MasterService { get; set; }
    }
}