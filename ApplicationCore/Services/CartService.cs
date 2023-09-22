using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using Ardalis.Result;

namespace ApplicationCore.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IAppLogger<CartService> _logger;

        public CartService(IRepository<Cart> cartRepository, IAppLogger<CartService> logger)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }
        public async Task<Cart> AddItemToCart(string userName, int catalogItemId, decimal price, int quantity = 1)
        {
            var cartSpec = new CartWithItemSpecification(userName);
            var cart = await _cartRepository.FirstOrDefaultAsync(cartSpec);

            if (cart == null)
            {
                cart = new Cart(userName);
                await _cartRepository.AddAsync(cart);
            }

            cart.AddItem(catalogItemId, price, quantity);   
            await _cartRepository.UpdateAsync(cart);
            return cart;
        }

        public async Task DeleteCartAsyn(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            Guard.Against.Null(cart, nameof(cart));
            await _cartRepository.DeleteAsync(cart);
        }

        public async Task<Result<Cart>> SetQuantities(int cartId, Dictionary<string, int> quantities)
        {
            var cartSpec = new CartWithItemSpecification(cartId);
            var cart = await _cartRepository.FirstOrDefaultAsync(cartSpec);
            if (cart == null) return Result<Cart>.NotFound();

            foreach(var item in cart.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    if (_logger != null) _logger.LoggingInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                    item.SetQuantity(quantity);
                }
            }

            cart.RemoveEmptyItems();
            await _cartRepository.UpdateAsync(cart);
            return cart;
        }

        public Task TransferCartAsync(string anonymousId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
