using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.CartAggregate
{
    public class Cart : BaseEntity
    {
        public string BuyerId { get; private set; }
        private readonly List<CartItem> _items = new List<CartItem>();
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();
        public int TotalItems => _items.Sum(i => i.Quantity);

        public Cart(string buyerId)
        {
            BuyerId = buyerId;
        }

        public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new CartItem(catalogItemId, quantity, unitPrice));
                return;
            }
            var existingItems = Items.First(i => i.CatalogItemId == catalogItemId);
            existingItems.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }

}
