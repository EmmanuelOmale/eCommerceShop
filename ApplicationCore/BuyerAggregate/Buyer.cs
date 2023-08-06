using System;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.BuyerAggregate
{
    public class Buyer : BaseEntity
    {
        public string IdentityGuid { get; private set; }

        private List<PaymentMethod> _paymentMethods => new List<PaymentMethod>();

        public IEnumerable<PaymentMethod> Payment => _paymentMethods.AsReadOnly();

        #pragma warning disable CS8618
        private Buyer()  { }

        public Buyer(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
    }
}
