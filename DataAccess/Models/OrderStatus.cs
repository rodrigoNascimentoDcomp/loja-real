using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public enum OrderStatus
    {
        Open,
        PendingPayment,
        AwaitingDelivery,
        Closed,
        Canceled,
        Returned
    }
}
