using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIFundamental.Models
{
    public enum OrderStatus
    {
        PENDING,
        AUTHORIZED,
        SHIPPED,
        CANCELLED,
        DELIVERED,
        RETURNED
    }
}