using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class CartNotFoundException : Exception
    {
        public CartNotFoundException(int cartId) : base($"no cart with id {cartId} was found")
        {
        }
    }
}
