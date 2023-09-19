using ApplicationCore.Entities.CartAggregate;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICartService
    {
        Task TransferCartAsync(string anonymousId, string userName);
        Task<Cart> AddItemToCart(string userName, int catalogItemId, decimal price, int quantity = 1);
        Task<Result<Cart>> SetQuantities(int cartId, Dictionary<string, int> quantities);
        Task DeleteCartAsyn(int cartId);
    }
}
