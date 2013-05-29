using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RetailPOS.CommonLayer.DataTransferObjects;

namespace RetailPOS.ServiceImplementation.ServiceContracts
{
    [ServiceContract]
    interface IRetailPOSServiceContract
    {
        #region Categories

        [OperationContract]
        IList<ProductCategoryDTO> GetCategories();

        #endregion

        #region Products

        [OperationContract]
        IList<ProductDTO> GetProductByCategory(int categoryId);

        #endregion
    }
}