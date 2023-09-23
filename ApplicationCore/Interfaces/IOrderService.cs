using ApplicationCore.Entities.OrderAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int cartId, Address shippingAddress);
    }
}