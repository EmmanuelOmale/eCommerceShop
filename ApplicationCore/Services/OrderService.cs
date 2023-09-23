using ApplicationCore.Entities;
using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using ApplicationCore.Extensions;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CatalogItem> _itemRepository;
        private readonly IUriComposer _uriComposer;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<Cart> cartRepository,
            IRepository<CatalogItem> itemRepository,
            IUriComposer uriComposer)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _uriComposer = uriComposer;
        }
        public async Task CreateOrderAsync(int cartId, Address shippingAddress)
        {
            var cartSpec = new CartWithItemSpecification(cartId);
            var cart = await _cartRepository.FirstOrDefaultAsync(cartSpec);

            Guard.Against.Null(cart, nameof(cart));
            Guard.Against.EmptyCartOnCheckout(cart.Items);

            var catalogItemsSpecification = new CatalogItemsSpecification(cart.Items.Select(item => item.CatalogItemId).ToArray());
            var catalogItems = await _itemRepository.ListAsync(catalogItemsSpecification);

            var items = cart.Items.Select(cartItems =>
            {
                var catalogItem = catalogItems.First(c => c.Id == cartItems.CatalogItemId);
                var itemOrdered = new CatalogItemOrdered(catalogItem.Id, catalogItem.Name, _uriComposer.ComposePicUri(catalogItem.PictureUri));
                var orderItem = new OrderItem(itemOrdered, cartItems.UnitPrice, cartItems.Quantity);
                return orderItem;
            }).ToList();

            var order = new Order(cart.BuyerId, shippingAddress, items);
            await _orderRepository.AddAsync(order);
        }
    }
}
