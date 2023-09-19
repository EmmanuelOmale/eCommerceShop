using ApplicationCore.Entities.CartAggregate;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public sealed class CartWithItemSpecification : Specification<Cart>, ISingleResultSpecification
    {
        public CartWithItemSpecification(int cartId)
        {
            Query
                .Where(c => c.Id == cartId)
                .Include(c => c.Items);
        }

        public CartWithItemSpecification(string buyerId)
        {
            Query
                .Where(b => b.BuyerId == buyerId)
                .Include(b => b.Items);
        }
    }
}
