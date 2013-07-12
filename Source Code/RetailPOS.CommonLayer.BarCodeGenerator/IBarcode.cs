#region Using directives

using System.Collections.Generic;

#endregion

namespace RetailPOS.CommonLayer.BarCodeGenerator
{
    interface IBarcode
    {
        string Encoded_Value
        {
            get;
        }//Encoded_Value

        string RawData
        {
            get;
        }//Raw_Data

        /// <summary>
        /// Errors
        /// </summary>
        List<string> Errors
        {
            get;
        }
    }
}