using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Interfaces;
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
        public Task<Cart> AddItemToCart(string userName, int catalogItemId, decimal price, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCartAsyn(int cartId)
        {
            throw new NotImplementedException();
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
