using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.BuyerAggregate
{
    public class PaymentMethod : BaseEntity
    {
        public string? Alias { get; private set; }
        public string? CardId { get; private set; }
        public string? Last4 { get; private set; }
    }
}
