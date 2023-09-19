using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Exceptions;
using Ardalis.GuardClauses;

namespace ApplicationCore.Extensions
{
    public static class CartGuard
    {
        public static void EmptyCartOnCheckout(this IGuardClause guardClause, IReadOnlyCollection<CartItem> cartItems)
        {
            if (!cartItems.Any())
                throw new EmptyCartOnCheckoutException();
        }
    }
}
