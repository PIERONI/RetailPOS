#region Using directives

using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;
using RetailPOS.BusinessLayer.Service.Admin;
using RetailPOS.BusinessLayer.Service.Customer;
using RetailPOS.BusinessLayer.Service.Masters;
using RetailPOS.BusinessLayer.Service.User;
using RetailPOS.CommonLayer.Unity;
using RetailPOS.ServiceImplementation.ServiceContracts;

#endregion

namespace RetailPOS.ServiceImplementation
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class RetailPOSService : IRetailPOSServiceContract
    {
        public RetailPOSService()
        {
            CategoryService = RetailPOSUnityContainer.Resolve<ICategoryService>();
            ProductService = RetailPOSUnityContainer.Resolve<IProductService>();
            StaffService = RetailPOSUnityContainer.Resolve<IStaffService>();
            UserService = RetailPOSUnityContainer.Resolve<IUserService>();
            CustomerService = RetailPOSUnityContainer.Resolve<ICustomerService>();
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
        /// Gets or sets the staff service.
        /// </summary>
        /// <value>
        /// The staff service.
        /// </value>
        [Dependency]
        public IStaffService StaffService { get; set; }

        /// <summary>
        /// Gets or sets the user service.
        /// </summary>
        /// <value>
        /// The user service.
        /// </value>
        [Dependency]
        public IUserService UserService { get; set; }

        /// <summary>
        /// Gets or sets the customer service.
        /// </summary>
        /// <value>
        /// The customer service.
        /// </value>
        [Dependency]
        public ICustomerService CustomerService { get; set; }

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