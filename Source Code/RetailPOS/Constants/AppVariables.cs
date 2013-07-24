using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailPOS.Constants
{
    public enum ViewModelType
    {
        Settings = 1,
        MenuControl = 2,
        MainWindow = 3
    }

    public enum OrderStatus
    {
        Normal = 1,
        SetAsideOrder = 2,
        OrderInQueue = 3
    }
}