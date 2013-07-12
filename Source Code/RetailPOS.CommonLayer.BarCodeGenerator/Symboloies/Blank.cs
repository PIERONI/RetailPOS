using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.CommonLayer.BarCodeGenerator.Symboloies
{
    class Blank : BarcodeCommon, IBarcode
    {
        public string Encoded_Value
        {
            get { throw new NotImplementedException(); }
        }
    }
}