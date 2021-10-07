using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Exceptions
{
    public class AlreadyCompletedOrderException:Exception
    {
        public AlreadyCompletedOrderException(string message) : base(message)
        {
        }
}
}
