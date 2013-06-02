#region Using directives

using Microsoft.Practices.Unity;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.CommonLayer.Unity;
using RetailPOS.ServiceImplementation.ServiceContracts;

#endregion

namespace RetailPOS.ServiceImplementation
{
    public partial class RetailPOSService : IRetailPOSServiceContract
    {
        public RetailPOSService()
        {
            CategoryService = RetailPOSUnityContainer.Resolve<ICategoryService>();
            ProductService = RetailPOSUnityContainer.Resolve<IProductService>();
        }

        /// <summary>
        /// Gets or sets the category service.
        /// </summary>
        /// <value>
        /// The category service.
        /// </value>
        [Dependency]
        public ICategoryService CategoryService { get; set; }

        /// <summary>
        /// Gets or sets the category service.
        /// </summary>
        /// <value>
        /// The category service.
        /// </value>
        [Dependency]
        public IProductService ProductService { get; set; }

        /// <summary>
        /// Gets or sets the master service.
        /// </summary>
        /// <value>
        /// The master service.
        /// </value>
        [Dependency]
        public IMasterService MasterService { get; set; }
    }
}