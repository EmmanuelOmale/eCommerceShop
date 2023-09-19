using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        public CartService(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
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

        public Task<Result<Cart>> SetQuantities(int cartId, Dictionary<string, int> quantities)
        {
            throw new NotImplementedException();
        }

        public Task TransferCartAsync(string anonymousId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
